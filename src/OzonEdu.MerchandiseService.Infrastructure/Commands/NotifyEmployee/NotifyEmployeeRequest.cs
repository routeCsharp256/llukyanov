using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.NotifyEmployee
{
    public class NotifyEmployeeRequest : IRequest
    {
        public long EmployeeId { get; init; }
        public string EmployeeEmail { get; init; }
    }
}