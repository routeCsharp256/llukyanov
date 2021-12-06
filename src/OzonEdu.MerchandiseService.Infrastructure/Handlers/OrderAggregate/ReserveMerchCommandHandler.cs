using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class ReserveMerchCommandHandler : IRequestHandler<ReserveMerchRequest, ReserveMerchResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOrderRepository _orderRepository;

        public ReserveMerchCommandHandler(IOrderRepository orderRepository, IEmployeeRepository employeeRepository)
        {
            _orderRepository = orderRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<ReserveMerchResponse> Handle(ReserveMerchRequest request,
            CancellationToken cancellationToken)
        {
            // Метод вызывается тогда, когда на склад поступают новые товары (по идее, поступление товаров должно в Кафку писаться)

            // 1. Получаем доступные товары с помощью метода GetAvailableQuantity() из StockItemRepository
            // 2. Получаем все доступные заказов, отсортированные по возрастанию дедлайна и убыванию приоритета

            var availableSkus = new List<Sku>(); 
            var orders = await _orderRepository.GetAllOpenOrdersAsync(cancellationToken);
            var orderedOrders = orders.OrderBy(o => o.Deadline).ThenByDescending(o => o.Priority.Id).ToList();

            foreach (var o in orderedOrders)
            {
                var a= await _orderRepository.ReserveSkusAsync(o.Id, availableSkus);                
            }
            
            // 3. Убираем со склада зарезервированные итемы командой GiveOutStockItems() из StockItemRepository
            // 4. Для всех заказов: если заказ завершён, меняем его статус с Active на Prepared
            // 5. Делаем UpdateAsync заказов

            throw new NotImplementedException();
        }
    }
}