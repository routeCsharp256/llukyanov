using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Infrastructure.Commands.CheckMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class CheckMerchCommandHandler : IRequestHandler<CheckMerchItemRequest, CheckMerchItemResponse>
    {
        private readonly IMerchItemRepository _merchItemRepository;

        public CheckMerchCommandHandler(IMerchItemRepository merchItemRepository)
        {
            _merchItemRepository = merchItemRepository;
        }

        public async Task<CheckMerchItemResponse> Handle(CheckMerchItemRequest itemRequest,
            CancellationToken cancellationToken)
        {
            var availableMerchItem = await _merchItemRepository.CheckMerchItemAsync(
                new Sku(itemRequest.Sku), new Quantity(itemRequest.Quantity), cancellationToken);
            if (availableMerchItem is null)
                throw new Exception("Something went wrong");

            return new CheckMerchItemResponse
            {
                Sku = availableMerchItem.Sku.Value,
                Quantity = availableMerchItem.Quantity.Value
            };
        }
    }
}