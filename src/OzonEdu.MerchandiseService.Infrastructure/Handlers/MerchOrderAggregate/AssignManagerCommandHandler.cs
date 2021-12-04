using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class AssignManagerCommandHandler : IRequestHandler<AssignManagerRequest>
    {
        private readonly IOrderRepository _orderRepository;

        public AssignManagerCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(AssignManagerRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId, cancellationToken);
            order.AssignManager(request.ManagerId);
            var result = await _orderRepository.UpdateAsync(order, cancellationToken);
            order.ChangeOrderStatus();
            return Unit.Value;
        }
    }
}