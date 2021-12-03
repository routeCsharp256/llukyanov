using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.NotifyEmployee
{
    public class NotifyEmployeeRequest : IRequest
    {
        public string EmployeeEmail { get; init; }
    }
}