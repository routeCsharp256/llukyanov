using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class ProbationPeriodEndedDomainEvent : INotification
    {
        public int EmployeeId { get; }
        
        public ProbationPeriodEndedDomainEvent(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}