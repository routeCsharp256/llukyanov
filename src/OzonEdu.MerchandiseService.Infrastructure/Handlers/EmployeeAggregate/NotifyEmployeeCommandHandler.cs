using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.NotifyEmployee;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Mocks;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class NotifyEmployeeCommandHandler : IRequestHandler<NotifyEmployeeRequest>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmailingServiceRepository _emailingServiceRepository;

        public NotifyEmployeeCommandHandler(IEmployeeRepository employeeRepository, IEmailingServiceRepository emailingServiceRepository)
        {
            _employeeRepository = employeeRepository;
            _emailingServiceRepository = emailingServiceRepository;
        }

        public async Task<Unit> Handle(NotifyEmployeeRequest request, CancellationToken cancellationToken)
        {
            var orderReadyMessage = await _employeeRepository.CreateOrderReadyNotification(request.OrderId, cancellationToken);
            await _emailingServiceRepository.SendMailSingle(orderReadyMessage.Email, orderReadyMessage.Subject, orderReadyMessage.Text, cancellationToken);
            return Unit.Value;
        }
    }
}