using System;
using System.Collections.Generic;
using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch
{
    public class CreateMerchPackRequest : IRequest<CreateMerchPackResponse>
    {
        public string Name { get; init; }

        public int EmployeeEventId { get; init; }

        public bool IsConference { get; init; }

        public List<long> MerchItemSkus { get; init; }
    }
}