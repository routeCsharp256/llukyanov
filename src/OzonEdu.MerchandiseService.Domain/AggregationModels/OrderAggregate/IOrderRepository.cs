using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate
{
    /// <summary>
    ///     Репозиторий для управления <see cref="Order" />
    /// </summary>
    public interface IOrderRepository : IRepository<Order>
    {
        /// <summary>
        ///     ЗЗафиксировать резерв полученных мерч-итемов
        /// </summary>
        /// <param name="skusReserved">ID заказа</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken" /></param>
        /// <returns>SKU оставшихся товаров</returns>>
        Task<IEnumerable<Sku>> ReserveSkusAsync(long orderId, List<Sku> skusReserved, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Получить описание заказа мерча по его ID
        /// </summary>
        /// <param name="orderId">ID заказа мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken" /></param>
        /// <returns>Заказ мерча</returns>
        Task<Order> GetOrderByIdAsync(long orderId, CancellationToken cancellationToken = default);
        
        /// <summary>
        ///     Получить все невыполненные заказы
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken" /></param>
        /// <returns>Заказ мерча</returns>
        Task<IEnumerable<Order>> GetAllOpenOrdersAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Получить описание всех заказа мерча для сотрудника по ID сотрудника
        /// </summary>
        /// <param name="employeeId">ID заказа мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken" /></param>
        /// <returns>Заказ мерча</returns>
        Task<IEnumerable<Order>> GetOrdersByEmployeeIdAsync(int employeeId,
            CancellationToken cancellationToken = default);
    }
}