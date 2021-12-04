using System;
using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class ReserveMerchRequest : IRequest<ReserveMerchResponse>
    {
    }
}