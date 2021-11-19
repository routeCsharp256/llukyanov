using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class MerchOrderCancelledDomainEventHandler : INotificationHandler<MerchOrderCancelledDomainEvent>
    {
        public Task Handle(MerchOrderCancelledDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}