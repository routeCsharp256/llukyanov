using System;
using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class CreateOrderByPackRequest : IRequest<CreateOrderByPackResponse>
    {
        public string EmployeeEmail { get; init; }

        public int Priority { get; init; }

        public int EmployeeEventId { get; init; }

        public int MerchPackId { get; init; }
        
        public DateTime Deadline { get; init; }
    }
}