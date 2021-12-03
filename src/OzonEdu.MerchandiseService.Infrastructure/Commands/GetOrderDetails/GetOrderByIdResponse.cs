using OzonEdu.MerchandiseService.Infrastructure.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch
{
    public class GetOrderByIdResponse
    {
        public OrderDto OrderDetails { get; init; }
    }
}