using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class AttendedConferenceAsSpeakerDomainEvent : INotification
    {
        public int EmployeeId { get; }
        public bool IsSpeaker { get; }
        
        public AttendedConferenceAsSpeakerDomainEvent(int employeeId)
        {
            EmployeeId = employeeId;
            IsSpeaker = true;
        }
    }
}