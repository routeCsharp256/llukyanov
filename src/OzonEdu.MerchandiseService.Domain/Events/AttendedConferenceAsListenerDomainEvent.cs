using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class AttendedConferenceAsListenerDomainEvent : INotification
    {
        public int EmployeeId { get; }
        public bool IsSpeaker { get; }
        
        public AttendedConferenceAsListenerDomainEvent(int employeeId)
        {
            EmployeeId = employeeId;
            IsSpeaker = false;
        }
    }
}