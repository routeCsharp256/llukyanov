using System;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class MerchOrderStatusChangedDomainEvent : INotification
    {
        public MerchOrderStatus Status { get; }
        public DateTime ChangedAt { get; }
        
        public MerchOrderStatusChangedDomainEvent(MerchOrderStatus status)
        {
            Status = status;
            ChangedAt = DateTime.Now;
        }
    }
}