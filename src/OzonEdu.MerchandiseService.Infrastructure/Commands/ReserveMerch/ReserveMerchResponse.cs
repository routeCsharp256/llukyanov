using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class ReserveMerchResponse
    {
        public List<long> SkusReserved { get; init; }
    }
}