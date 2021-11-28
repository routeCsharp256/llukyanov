using System.Collections.Generic;
using OzonEdu.MerchandiseService.Infrastructure.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class GetOrdersByEmployeeIdResponse
    {
        public IReadOnlyList<OrderDto> Orders { get; init; }
    }
}