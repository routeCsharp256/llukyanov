using System;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAgregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class OrderStatusChangedDomainEvent : INotification
    {
        public OrderStatusChangedDomainEvent(OrderStatus status, DateTime datetime)
        {
            Status = status;
            ChangedAt = datetime;
        }

        public OrderStatus Status { get; }
        public DateTime ChangedAt { get; }
    }
}