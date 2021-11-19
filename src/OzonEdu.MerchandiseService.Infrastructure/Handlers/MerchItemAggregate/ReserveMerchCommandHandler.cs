using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch;
using OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class ReserveMerchCommandHandler : IRequestHandler<ReserveMerchItemsRequest, ReserveMerchItemsResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMerchOrderRepository _merchOrderRepository;

        public ReserveMerchCommandHandler(IMerchOrderRepository merchOrderRepository, IEmployeeRepository employeeRepository)
        {
            _merchOrderRepository = merchOrderRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<ReserveMerchItemsResponse> Handle(ReserveMerchItemsRequest reserveMerchItemsRequest, CancellationToken cancellationToken)
        {
            // проверить, создан ли запрос на выдачу с таким id
            // если да, то выбрать этот запрос из БД
            // Посмотреть, какие мерч-итемы ещё не зарезервированы
            // напроавить запрос на резервирование
            // проапдейтить запрос
            // сохранить в БД
            
            
            
            // if (reserveMerchItemsRequest. is not null)
            // {
            //     var isMerchReceived = await _employeeRepository.IsEventMerchReceived(itemRequest.EmployeeId,
            //         itemRequest.EmployeeEventTypeId, new Sku(itemRequest.Sku),
            //         cancellationToken);
            //
            //     if (isMerchReceived)
            //         return new AskMerchItemResponse
            //         {
            //             Sku = itemRequest.Sku,
            //             Quantity = 0
            //         };
            // }
            //
            // var availableMerchItems = await _merchItemRepository.CheckMerchItemAsync(
            //     new Sku(itemRequest.Sku), new Quantity(itemRequest.Quantity), cancellationToken);
            //
            // if (availableMerchItems.Quantity.Value < itemRequest.Quantity)
            //     await _merchItemRepository.ReserveMerchItemAsync(itemRequest.EmployeeId,
            //         new Sku(itemRequest.Sku), new Quantity(itemRequest.Quantity - availableMerchItems.Quantity.Value),
            //         cancellationToken);
            //
            return new ReserveMerchItemsResponse();
        }
    }
}