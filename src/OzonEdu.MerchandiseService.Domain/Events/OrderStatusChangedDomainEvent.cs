using System;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class OrderStatusChangedDomainEvent : INotification
    {
        public OrderStatusChangedDomainEvent(OrderStatus status)
        {
            Status = status;
            ChangedAt = DateTime.Now;
        }

        public OrderStatus Status { get; }
        public DateTime ChangedAt { get; }
    }
}