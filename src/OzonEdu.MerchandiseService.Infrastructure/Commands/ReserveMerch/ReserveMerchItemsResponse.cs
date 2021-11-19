using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch
{
    public class ReserveMerchItemsResponse
    {
        public List<long> ReservedSkus { get; init; }
    }
}