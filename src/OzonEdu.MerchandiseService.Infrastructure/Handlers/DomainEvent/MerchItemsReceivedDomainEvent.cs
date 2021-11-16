using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class MerchItemsReceivedDomainEventHandler : INotificationHandler<MerchItemsReceivedDomainEvent>
    {
        public Task Handle(MerchItemsReceivedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}