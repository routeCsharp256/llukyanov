using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch;
using OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class
        CreateOrderManuallyCommandHandler : IRequestHandler<CreateOrderManuallyRequest, CreateOrderManuallyResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderManuallyCommandHandler(IOrderRepository orderRepository,
            IEmployeeRepository employeeRepository)
        {
            _orderRepository = orderRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<CreateOrderManuallyResponse> Handle(CreateOrderManuallyRequest request,
            CancellationToken cancellationToken)
        {
            var orderDetails = new Order(request.EmployeeEmail, request.Skus, null, OrderPriority.Medium, new NullableDate(request.Deadline));
            var newOrder = await _orderRepository.CreateAsync(orderDetails, cancellationToken);
            return new CreateOrderManuallyResponse
            {
                OrderId = newOrder.Id
            };
        }
    }
}