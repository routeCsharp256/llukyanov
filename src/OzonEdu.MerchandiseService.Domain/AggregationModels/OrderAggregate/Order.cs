using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAgregate;
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
            OrderPriority priority, 
            NullableDate deadline)
        {
            var createdAt = DateTime.Now;
            
            EmployeeEmail = new Email(employeeEmail);
            SkusRequested = skusRequested.Select(sku => new Sku(sku)).ToList();
            MerchPackId = merchPackId;
            Priority = priority;
            Deadline = deadline;

            Status = OrderStatus.New;
            CreatedAt = createdAt;

            AddOrderStatusChangedDomainEvent(OrderStatus.New, createdAt);
        }

        public long Id { get; }

        public Email EmployeeEmail { get; }

        public IReadOnlyList<Sku> SkusRequested { get; }

        /// <summary>
        ///     Список товаров, зарезервированных для выдачи.
        /// </summary>
        public List<Sku> SkusReserved { get; } = new();

        public int? MerchPackId { get; }

        public OrderStatus Status { get; private set; }

        public OrderPriority Priority { get; }

        public DateTime CreatedAt { get; }

        public NullableDate ClosedAt { get; private set; }

        /// <summary>
        ///     Заполняется, если набор мерча нужно выдать не позднее какой-то даты (например, перед конференцией)
        /// </summary>
        public NullableDate Deadline { get; }

        /// <summary>
        ///     id менеджера, с которым можно связаться по статусу заказа
        /// </summary>
        public int? ManagerId { get; private set; }

        public bool IsEmployeeReceivedOrder { get; private set; }


        public void ChangeOrderStatus()
        {
            if (Status.Equals(OrderStatus.New) && ManagerId is not null)
            {
                Status = OrderStatus.Active;
                AddOrderStatusChangedDomainEvent(OrderStatus.Active, DateTime.Now);
            }

            if (Status.Equals(OrderStatus.Active) && SkusRequested.SequenceEqual(SkusReserved))
            {
                Status = OrderStatus.Prepared;
                AddOrderStatusChangedDomainEvent(OrderStatus.Prepared, DateTime.Now);
            }

            if (Status.Equals(OrderStatus.Prepared) && IsEmployeeReceivedOrder)
            {
                ClosedAt = new NullableDate(DateTime.Now);

                Status = OrderStatus.Closed;
                AddOrderStatusChangedDomainEvent(OrderStatus.Closed, DateTime.Now);
            }
        }

        public void CancelOrder()
        {
            Status = OrderStatus.Cancelled;
            AddOrderStatusChangedDomainEvent(OrderStatus.Cancelled, DateTime.Now);
        }

        public void SetOrderReceivedByEmployee()
        {
            IsEmployeeReceivedOrder = true;
        }

        public void AssignManager(int managerId)
        {
            ManagerId = managerId;
        }

        public void AddSkusReserved(List<Sku> skusReserved)
        {
            if (!SkusRequested.Intersect(skusReserved).SequenceEqual(skusReserved))
                throw new AggregateException("There are items that should not be added to order");
            if (SkusRequested.Intersect(skusReserved).SequenceEqual(skusReserved))
                SkusReserved.AddRange(skusReserved.Except(SkusReserved));
        }

        private void AddOrderStatusChangedDomainEvent(OrderStatus status, DateTime date)
        {
            var orderStatusChangedDomainEvent = new OrderStatusChangedDomainEvent(status, date);
            AddDomainEvent(orderStatusChangedDomainEvent);
        }
    }
}