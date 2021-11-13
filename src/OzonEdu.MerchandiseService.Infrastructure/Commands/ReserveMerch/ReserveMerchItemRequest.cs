using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class ReserveMerchItemRequest : IRequest
    {
        public int EmployeeId { get; init; }
        public long Sku { get; init; }
        public int Quantity { get; init; }
    }
}