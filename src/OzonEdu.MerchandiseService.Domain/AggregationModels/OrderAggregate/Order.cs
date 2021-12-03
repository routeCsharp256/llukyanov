using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate
{
    public class Order : Entity
    {
        public Order(
            string employeeEmail,
            List<long> skusRequested,
            int? merchPackId,
            OrderPriority priority)
        {
            EmployeeEmail = new Email(employeeEmail);
            SkusRequested = skusRequested.Select(sku => new Sku(sku)).ToList();
            MerchPackId = merchPackId;
            Priority = priority;

            Status = OrderStatus.New;
            CreatedAt = new NullableDate(DateTime.Now);

            AddOrderCreatedDomainEvent();
        }

        public long Id { get; }

        public Email EmployeeEmail { get; }

        public IReadOnlyList<Sku> SkusRequested { get; }

        /// <summary>
        ///     Список товаров, зарезервированных для выдачи.
        ///     Резерв может быть снят только если заказ будет отменён (Status = Cancelled)
        ///     или когда сотрудник забрал заказ
        /// </summary>
        public List<Sku> SkusReserved { get; } = new();

        public int? MerchPackId { get; }

        public OrderStatus Status { get; private set; }

        public OrderPriority Priority { get; }

        public NullableDate CreatedAt { get; }

        public NullableDate ClosedAt { get; set; }

        /// <summary>
        ///     Заполняется, если набор мерча нужно выдать не позднее какой-то даты (например, перед конференцией)
        /// </summary>
        public NullableDate Deadline { get; }

        public int? ManagerId { get; set; } // id менеджера, с которым можно связаться по статусу заказа

        public bool IsEmployeeReceivedOrder { get; private set; }


        public void ChangeOrderStatus()
        {
            if (Status.Equals(OrderStatus.New) && ManagerId is not null)
            {
                Status = OrderStatus.Active;
                AddOrderActiveDomainEvent();
                AddOrderStatusChangedDomainEvent(OrderStatus.Active);
            }

            if (Status.Equals(OrderStatus.Active) && SkusRequested.SequenceEqual(SkusReserved))
            {
                Status = OrderStatus.Prepared;
                AddOrderPreparedDomainEvent();
                AddOrderStatusChangedDomainEvent(OrderStatus.Prepared);
            }

            if (Status.Equals(OrderStatus.Prepared) && IsEmployeeReceivedOrder)
            {
                ClosedAt = new NullableDate(DateTime.Now);

                Status = OrderStatus.Closed;
                AddOrderStatusChangedDomainEvent(OrderStatus.Closed);
            }
        }

        public void CancelOrder()
        {
            Status = OrderStatus.Cancelled;
            AddOrderCancelledDomainEvent();
        }

        public void SetOrderReceivedByEmployee()
        {
            IsEmployeeReceivedOrder = true;
        }

        public void AddSkusReserved(List<Sku> skusReserved)
        {
            if (!SkusRequested.Intersect(skusReserved).SequenceEqual(skusReserved))
                throw new AggregateException("There are items that should not be added to order");
            if (SkusRequested.Intersect(skusReserved).SequenceEqual(skusReserved))
                SkusReserved.AddRange(skusReserved.Except(SkusReserved));
        }

        private void AddOrderCreatedDomainEvent()
        {
            var orderClosedDomainEvent = new OrderClosedDomainEvent();
            AddDomainEvent(orderClosedDomainEvent);
        }

        private void AddOrderStatusChangedDomainEvent(OrderStatus status)
        {
            var orderStatusChangedDomainEvent = new OrderStatusChangedDomainEvent(status);
            AddDomainEvent(orderStatusChangedDomainEvent);
        }

        private void AddOrderCancelledDomainEvent()
        {
            var orderCancelledDomainEvent = new OrderCancelledDomainEvent();
            AddDomainEvent(orderCancelledDomainEvent);
        }

        private void AddOrderPreparedDomainEvent()
        {
            var orderPreparedDomainEvent = new OrderPreparedDomainEvent(EmployeeEmail);
            AddDomainEvent(orderPreparedDomainEvent);
        }

        private void AddOrderActiveDomainEvent()
        {
            var orderActiveDomainEvent = new OrderActiveDomainEvent();
            AddDomainEvent(orderActiveDomainEvent);
        }
    }
}