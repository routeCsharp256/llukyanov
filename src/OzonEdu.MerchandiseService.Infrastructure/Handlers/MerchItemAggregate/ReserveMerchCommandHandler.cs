using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class ReserveMerchCommandHandler : IRequestHandler<ReserveMerchItemRequest>
    {
        private readonly IMerchItemRepository _merchItemRepository;

        public ReserveMerchCommandHandler(IMerchItemRepository merchItemRepository)
        {
            _merchItemRepository = merchItemRepository;
        }

        public async Task<Unit> Handle(ReserveMerchItemRequest itemRequest, CancellationToken cancellationToken)
        {
            await _merchItemRepository.ReserveMerchItemAsync(
                itemRequest.EmployeeId, new Sku(itemRequest.Sku), new Quantity(itemRequest.Quantity),
                cancellationToken);

            return Unit.Value;
        }
    }
}