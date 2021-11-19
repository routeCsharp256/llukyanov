using System.Collections.Generic;
using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch
{
    public class AskMerchItemRequest : IRequest<AskMerchItemResponse>
    {
        public int EmployeeId { get; init; }
        public int? EmployeeEventTypeId { get; init; }
        public IReadOnlyList<long> Skus { get; init; }
    }
}