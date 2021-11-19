using System.Collections.Generic;
using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.CheckMerch
{
    public class CheckMerchItemRequest : IRequest<CheckMerchItemResponse>
    {
        public IReadOnlyList<long> Sku { get; init; }
    }
}