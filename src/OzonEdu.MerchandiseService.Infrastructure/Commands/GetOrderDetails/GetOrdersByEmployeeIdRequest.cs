using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class GetOrdersByEmployeeIdRequest : IRequest<GetOrdersByEmployeeIdResponse>
    {
        public int EmployeeId { get; init; }
    }
}