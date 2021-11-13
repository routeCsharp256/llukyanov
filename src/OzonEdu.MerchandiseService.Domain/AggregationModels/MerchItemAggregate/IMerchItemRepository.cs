using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    /// <summary>
    ///     Репозиторий для управления <see cref="MerchItem" />
    /// </summary>
    public interface IMerchItemRepository : IRepository<MerchItem>
    {
        /// <summary>
        ///     Запросить мерч для сотрудника
        /// </summary>
        /// <param name="merchItems">Список мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции.<see cref="CancellationToken" /></param>
        /// <returns>Список запрошенного мерча</returns>
        Task<MerchItem> AskMerchItemAsync(int employeeId, Sku sku, Quantity quantity,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Запросить мерч для сотрудника, всвязи с каким-то событием
        /// </summary>
        /// <param name="merchItems">Список мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции.<see cref="CancellationToken" /></param>
        /// <returns>Список запрошенного мерча</returns>
        Task<MerchItem> AskMerchItemAsync(int employeeId, EmployeeEventType employeeEventType, Sku sku,
            Quantity quantity, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Проверить наличие мерч
        /// </summary>
        /// <param name="merchItems">Список мерча</param>
        /// \
        /// <param name="cancellationToken">Токен для отмены операции.<see cref="CancellationToken" /></param>
        /// <returns>Список запрошенного мерча, который есть в наличии</returns>
        Task<MerchItem> CheckMerchItemAsync(Sku sku, Quantity quantity, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Зарезервировать мерч для сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="merchItems">Список мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции.<see cref="CancellationToken" /></param>
        /// <returns>Список мерча для резервирования</returns>
        Task ReserveMerchItemAsync(int employeeId, Sku sku, Quantity quantity,
            CancellationToken cancellationToken = default);
    }
}