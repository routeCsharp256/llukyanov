using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch;
using OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch;
using OzonEdu.MerchandiseService.Infrastructure.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GetOrderByIdCommandHandler : IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId, cancellationToken);
            return new GetOrderByIdResponse
            {
                OrderDetails = new OrderDto
                {
                    Id = order.Id,
                    EmployeeEmail = order.EmployeeEmail.Value,
                    SkusRequested = order.SkusRequested.Select(x => x.Value).ToList(),
                    SkusReserved = order.SkusReserved.Select(x => x.Value).ToList(),
                    MerchPackId = order.MerchPackId,
                    StatusId = order.Status.Id,
                    PriorityId = order.Priority.Id,
                    CreatedAt = order.CreatedAt,
                    ClosedAt = order.ClosedAt.Value,
                    Deadline = order.Deadline.Value,
                    ManagerId = order.ManagerId,
                    IsEmployeeReceivedOrder = order.IsEmployeeReceivedOrder
                }
            };
        }
    }
}