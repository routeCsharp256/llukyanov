using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class OrderActiveDomainEventHandler : INotificationHandler<OrderActiveDomainEvent>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderActiveDomainEventHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public async Task Handle(OrderActiveDomainEvent notification, CancellationToken cancellationToken)
        {
            await _orderRepository.TryReserveMerchItemsAsync(cancellationToken);
        }
    }
}