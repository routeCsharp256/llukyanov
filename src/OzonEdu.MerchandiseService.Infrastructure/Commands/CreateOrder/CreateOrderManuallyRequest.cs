using System;
using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class CreateOrderManuallyRequest : IRequest<CreateOrderManuallyResponse>
    {
        public string EmployeeEmail { get; init; }

        public int Priority { get; init; }

        public List<long> Skus { get; init; } = new();
        
        public DateTime Deadline { get; init; }
    }
}