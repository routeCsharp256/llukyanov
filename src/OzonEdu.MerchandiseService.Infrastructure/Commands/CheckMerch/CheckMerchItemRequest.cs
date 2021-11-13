using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.CheckMerch
{
    public class CheckMerchItemRequest : IRequest<CheckMerchItemResponse>
    {
        public long Sku { get; init; }
        public int Quantity { get; init; }
    }
}