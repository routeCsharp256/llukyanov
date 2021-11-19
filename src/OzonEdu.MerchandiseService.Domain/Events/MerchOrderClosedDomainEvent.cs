using System;
using MediatR;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class MerchOrderClosedDomainEvent : INotification
    {
        public DateTime ClosedAt { get; }
        
        public MerchOrderClosedDomainEvent()
        {
            ClosedAt = DateTime.Now;
        }
    }
}