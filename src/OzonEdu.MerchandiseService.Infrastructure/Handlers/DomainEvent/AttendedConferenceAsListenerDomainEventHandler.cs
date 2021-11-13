using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class
        AttendedConferenceAsListenerDomainEventHandler : INotificationHandler<AttendedConferenceAsListenerDomainEvent>
    {
        public Task Handle(AttendedConferenceAsListenerDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}