using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class MerchOrderCreatedDomainEventHandler : INotificationHandler<MerchOrderCreatedDomainEvent>
    {
        public Task Handle(MerchOrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}