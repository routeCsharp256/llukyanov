using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class
        AttendedConferenceAsSpeakerDomainEventHandler : INotificationHandler<AttendedConferenceAsSpeakerDomainEvent>
    {
        public Task Handle(AttendedConferenceAsSpeakerDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}