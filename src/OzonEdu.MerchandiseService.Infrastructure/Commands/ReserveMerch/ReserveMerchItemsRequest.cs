using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class ReserveMerchItemsRequest : IRequest<ReserveMerchItemsResponse>
    {
        public long MerchOrderId { get; init; }
    }
}