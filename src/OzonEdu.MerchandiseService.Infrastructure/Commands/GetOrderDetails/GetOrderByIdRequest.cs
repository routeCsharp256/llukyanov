using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class GetOrderByIdRequest : IRequest<GetOrderByIdResponse>
    {
        public long OrderId { get; init; }
    }
}