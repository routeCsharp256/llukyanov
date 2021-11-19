using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    public class MerchOrder : Entity
    {
        public MerchOrder(
            long id,
            int employeeId,
            List<Sku> skusRequested,
            MerchPack merchPack,
            MerchOrderPriority priority,
            Date deadline)
        {
            Id = id;
            EmployeeId = employeeId; 
            SkusRequested = skusRequested;
            MerchPack = merchPack;
            Priority = priority;
            Deadline = deadline;

            Status = MerchOrderStatus.New;
            CreatedAt = new Date(DateTime.Now);

            AddMerchOrderCreatedDomainEvent();
        }

        public long Id { get; }
        
        
        public int EmployeeId { get; }

        public IReadOnlyList<Sku> SkusRequested { get; }

        /// <summary>
        ///     Список товаров, зарезервированных для выдачи.
        ///     Резерв может быть снят только если заказ будет отменён (Status = Cancelled)
        ///     или когда сотрудник забрал заказ
        /// </summary>
        public List<Sku> SkusReserved { get; } = new List<Sku>(); 

        public MerchPack MerchPack { get; }

        public MerchOrderStatus Status { get; private set; }

        public MerchOrderPriority Priority { get; }

        public Date CreatedAt { get; }

        public Date ClosedAt { get; set; }
        
        /// <summary>
        ///     Заполняется, если набор мерча нужно выдать не позднее какой-то даты (например, перед конференцией)
        /// </summary>
        public Date Deadline { get; }

        public int? ManagerId { get; set; } // id менеджера, с которым можно связаться по статусу заказа

        public bool IsEmployeeReceivedOrder { get; private set; }


        private void ChangeMerchOrderStatus(MerchOrderStatus status)
        {
            if (Status.Equals(MerchOrderStatus.New) && status.Equals(MerchOrderStatus.Closed))
                throw new ChangeStatusException("Cannot change status from 'New' to 'Closed'");

            if (Status.Equals(MerchOrderStatus.New) && status.Equals(MerchOrderStatus.Active) && ManagerId is null)
                throw new ChangeStatusException("Cannot change status from 'New' to 'Active': manager is not assigned");

            if (Status.Equals(MerchOrderStatus.Active) && status.Equals(MerchOrderStatus.Closed)
                                                       && SkusRequested.Except(SkusReserved).Any())
                throw new ChangeStatusException(
                    "Cannot change status from 'Active' to 'Closed': not all merch items were prepared");

            if (Status.Equals(MerchOrderStatus.Active) && status.Equals(MerchOrderStatus.Closed)
                                                       && !IsEmployeeReceivedOrder)
                throw new ChangeStatusException(
                    "Cannot change status from 'Active' to 'Closed': employee have not received order yet");

            Status = status;
            if (status.Equals(MerchOrderStatus.Closed))
                ClosedAt = new Date(DateTime.Now);
            AddMerchOrderStatusChangedDomainEvent(status);
        }

        private void CancelMerchOrder()
        {
            Status = MerchOrderStatus.Cancelled;
            AddMerchOrderCancelledDomainEvent();
        }

        private void SetOrderReceivedByEmployee()
        {
            IsEmployeeReceivedOrder = true;
        }

        private void AddSkusReserved(List<Sku> skusReserved)
        {
            if (!SkusRequested.Intersect(skusReserved).SequenceEqual(skusReserved))
                throw new AggregateException("There are items that should not be added to order");
            if (SkusRequested.Intersect(skusReserved).SequenceEqual(skusReserved))
                SkusReserved.AddRange(skusReserved.Except(SkusReserved));
            // TODO: добавить доменный эвент на бронь мерча
        }


        private void AddMerchOrderCreatedDomainEvent()
        {
            var merchOrderClosedDomainEvent = new MerchOrderClosedDomainEvent();
            AddDomainEvent(merchOrderClosedDomainEvent);
        }

        private void AddMerchOrderStatusChangedDomainEvent(MerchOrderStatus status)
        {
            var merchOrderStatusChangedDomainEvent = new MerchOrderStatusChangedDomainEvent(status);
            AddDomainEvent(merchOrderStatusChangedDomainEvent);
        }

        private void AddMerchOrderCancelledDomainEvent()
        {
            var merchOrderCancelledDomainEvent = new MerchOrderCancelledDomainEvent();
            AddDomainEvent(merchOrderCancelledDomainEvent);
        }
    }
}