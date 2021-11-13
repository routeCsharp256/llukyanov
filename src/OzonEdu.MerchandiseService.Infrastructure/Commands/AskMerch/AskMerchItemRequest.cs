using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch
{
    public class AskMerchItemRequest : IRequest<AskMerchItemResponse>
    {
        public int EmployeeId { get; init; }
        public int? EmployeeEventTypeId { get; init; }
        public long Sku { get; init; }
        public int Quantity { get; init; }
    }
}