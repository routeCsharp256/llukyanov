using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class OrderCancelledDomainEventHandler : INotificationHandler<OrderCancelledDomainEvent>
    {
        public Task Handle(OrderCancelledDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}