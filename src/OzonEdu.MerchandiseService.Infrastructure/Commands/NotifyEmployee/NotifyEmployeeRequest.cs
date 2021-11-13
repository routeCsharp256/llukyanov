using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.NotifyEmployee
{
    public class NotifyEmployeeRequest : IRequest
    {
        public int EmployeeId { get; init; }
    }
}