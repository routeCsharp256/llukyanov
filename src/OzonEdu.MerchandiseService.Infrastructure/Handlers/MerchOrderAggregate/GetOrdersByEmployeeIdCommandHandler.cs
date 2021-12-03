using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch;
using OzonEdu.MerchandiseService.Infrastructure.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class
        GetOrdersByEmployeeIdCommandHandler : IRequestHandler<GetOrdersByEmployeeIdRequest,
            GetOrdersByEmployeeIdResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByEmployeeIdCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrdersByEmployeeIdResponse> Handle(GetOrdersByEmployeeIdRequest request,
            CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByEmployeeIdAsync(request.EmployeeId, cancellationToken);

            var result = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                EmployeeEmail = o.EmployeeEmail.Value,
                SkusRequested = o.SkusRequested.Select(x => x.Value).ToList(),
                SkusReserved = o.SkusReserved.Select(x => x.Value).ToList(),
                MerchPackId = o.MerchPackId,
                StatusId = o.Status.Id,
                PriorityId = o.Priority.Id,
                CreatedAt = o.CreatedAt.Value,
                ClosedAt = o.ClosedAt.Value,
                Deadline = o.Deadline.Value,
                ManagerId = o.ManagerId,
                IsEmployeeReceivedOrder = o.IsEmployeeReceivedOrder
            }).ToList();

            return new GetOrdersByEmployeeIdResponse
            {
                Orders = result
            };
        }
    }
}