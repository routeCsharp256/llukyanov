using System;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAgregate;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class OrderActiveDomainEvent : INotification
    {
        public DateTime ActiveAt { get; } 
        
        public OrderActiveDomainEvent()
        {
            ActiveAt = DateTime.Now;
        }
    }
}