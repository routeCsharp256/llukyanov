using System.Collections.Generic;
using OzonEdu.MerchandiseService.Infrastructure.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.CheckMerch
{
    public class CheckMerchItemResponse
    {
        public IReadOnlyList<StockItemDto> StockItemsAvailable { get; init; }
    }
}