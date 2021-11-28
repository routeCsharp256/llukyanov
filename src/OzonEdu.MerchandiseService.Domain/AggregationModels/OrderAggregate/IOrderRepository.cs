using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate
{
    /// <summary>
    ///     Репозиторий для управления <see cref="Order" />
    /// </summary>
    public interface IOrderRepository : IRepository<Order>
    {
        /// <summary>
        ///     Проверить наличие мерча для всех открытых заказов
        /// </summary>
        /// <param name="orderId">ID заказа</param>
        /// <param name="skus">Список SKU</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken" /></param>
        /// <returns>Список запрошенного мерча, который есть в наличии</returns>
        Task TryReserveMerchItemsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Получить описание заказа мерча по его ID
        /// </summary>
        /// <param name="OrderId">ID заказа мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken" /></param>
        /// <returns>Заказ мерча</returns>
        Task<Order> GetOrderByIdAsync(long OrderId, CancellationToken cancellationToken = default);

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