using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class AssignManagerRequest : IRequest
    {
        public int OrderId { get; init; }
        public int ManagerId { get; init; }
    }
}