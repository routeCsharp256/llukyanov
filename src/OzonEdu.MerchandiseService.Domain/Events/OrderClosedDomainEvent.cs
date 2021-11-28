using System;
using MediatR;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class OrderClosedDomainEvent : INotification
    {
        public OrderClosedDomainEvent()
        {
            ClosedAt = DateTime.Now;
        }

        public DateTime ClosedAt { get; }
    }
}