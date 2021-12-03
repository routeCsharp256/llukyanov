using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class OrderClosedDomainEventHandler : INotificationHandler<OrderClosedDomainEvent>
    {
        public Task Handle(OrderClosedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}