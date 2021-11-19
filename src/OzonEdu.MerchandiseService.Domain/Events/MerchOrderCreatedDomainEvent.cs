using System;
using MediatR;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class MerchOrderCreatedDomainEvent : INotification
    {
        public DateTime CreatedAt { get; }

        public MerchOrderCreatedDomainEvent()
        {
            CreatedAt = DateTime.Now;
        }
    }
}