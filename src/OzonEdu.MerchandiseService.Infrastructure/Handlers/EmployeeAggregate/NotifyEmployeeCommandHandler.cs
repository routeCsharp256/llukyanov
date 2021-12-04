using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.NotifyEmployee;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class NotifyEmployeeCommandHandler : IRequestHandler<NotifyEmployeeRequest>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public NotifyEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(NotifyEmployeeRequest itemRequest, CancellationToken cancellationToken)
        {
            await _employeeRepository.NotifyEmployeeAboutMerchAsync(itemRequest.EmployeeEmail, cancellationToken);
            return Unit.Value;
        }
    }
}