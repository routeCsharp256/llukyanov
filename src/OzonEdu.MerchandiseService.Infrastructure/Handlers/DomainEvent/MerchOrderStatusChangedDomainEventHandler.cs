using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class MerchOrderStatusChangedDomainEventHandler : INotificationHandler<MerchOrderStatusChangedDomainEvent>
    {
        public Task Handle(MerchOrderStatusChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}