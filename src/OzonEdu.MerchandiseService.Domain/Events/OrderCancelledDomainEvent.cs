using System;
using MediatR;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class OrderCancelledDomainEvent : INotification
    {
        public OrderCancelledDomainEvent()
        {
            CancelledAt = DateTime.Now;
        }

        public DateTime CancelledAt { get; }
    }
}