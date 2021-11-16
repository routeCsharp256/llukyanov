using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class HiredDomainEvent : INotification
    {
        public int EmployeeId { get; }
        
        public HiredDomainEvent(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}