using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class MerchItemsReservedDomainEventHandler : INotificationHandler<MerchItemsReservedDomainEvent>
    {
        public Task Handle(MerchItemsReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}