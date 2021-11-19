using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class MerchOrderClosedDomainEventHandler : INotificationHandler<MerchOrderClosedDomainEvent>
    {
        public Task Handle(MerchOrderClosedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}