using System;
using MediatR;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class OrderCreatedDomainEvent : INotification
    {
        public OrderCreatedDomainEvent()
        {
            CreatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; }
    }
}