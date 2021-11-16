using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class BecameVeteranDomainEvent : INotification
    {
        public int EmployeeId { get; }
        
        public BecameVeteranDomainEvent(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}