using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class AskMerchCommandHandler : IRequestHandler<AskMerchItemRequest, AskMerchItemResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMerchItemRepository _merchItemRepository;

        public AskMerchCommandHandler(IMerchItemRepository merchItemRepository, IEmployeeRepository employeeRepository)
        {
            _merchItemRepository = merchItemRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<AskMerchItemResponse> Handle(AskMerchItemRequest itemRequest,
            CancellationToken cancellationToken)
        {
            if (itemRequest.EmployeeEventTypeId is not null)
            {
                var isMerchReceived = await _employeeRepository.IsEventMerchReceived(itemRequest.EmployeeId,
                    itemRequest.EmployeeEventTypeId, new Sku(itemRequest.Sku), new Quantity(itemRequest.Quantity),
                    cancellationToken);

                if (isMerchReceived)
                    return new AskMerchItemResponse
                    {
                        Sku = itemRequest.Sku,
                        Quantity = 0
                    };
            }

            var availableMerchItems = await _merchItemRepository.CheckMerchItemAsync(
                new Sku(itemRequest.Sku), new Quantity(itemRequest.Quantity), cancellationToken);

            if (availableMerchItems.Quantity.Value < itemRequest.Quantity)
                await _merchItemRepository.ReserveMerchItemAsync(itemRequest.EmployeeId,
                    new Sku(itemRequest.Sku), new Quantity(itemRequest.Quantity - availableMerchItems.Quantity.Value),
                    cancellationToken);

            return new AskMerchItemResponse
            {
                Sku = availableMerchItems.Sku.Value,
                Quantity = availableMerchItems.Quantity.Value
            };
        }
    }
}