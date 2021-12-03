using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class OrderPreparedDomainEventHandler : INotificationHandler<OrderPreparedDomainEvent>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public OrderPreparedDomainEventHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Handle(OrderPreparedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _employeeRepository.NotifyEmployeeAboutMerchAsync(notification.EmployeeEmail.Value,
                cancellationToken);
        }
    }
}