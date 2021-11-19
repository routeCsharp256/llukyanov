using System;
using MediatR;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class MerchOrderCancelledDomainEvent : INotification
    {
        public DateTime CancelledAt { get; }
        
        public MerchOrderCancelledDomainEvent()
        {
            CancelledAt = DateTime.Now;
        }
    }
}