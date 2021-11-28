using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class CreateOrderByPackCommandHandler : IRequestHandler<CreateOrderByPackRequest, CreateOrderByPackResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOrderRepository _OrderRepository;

        public CreateOrderByPackCommandHandler(IOrderRepository orderRepository, IEmployeeRepository employeeRepository)
        {
            _OrderRepository = orderRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<CreateOrderByPackResponse> Handle(CreateOrderByPackRequest request,
            CancellationToken cancellationToken)
        {
            var orderDetails = new Order(request.EmployeeEmail, null, request.MerchPackId, OrderPriority.Medium);
            var isMerchPackReceived = await _employeeRepository.CheckIsMerchPackReceivedAsync(request.EmployeeEmail,
                request.EmployeeEventId, request.MerchPackId, cancellationToken);
            if (!isMerchPackReceived)
            {
                var newOrder = await _OrderRepository.CreateAsync(orderDetails, cancellationToken);
                return new CreateOrderByPackResponse
                {
                    OrderId = newOrder.Id
                };
            }

            return new CreateOrderByPackResponse();
        }
    }
}