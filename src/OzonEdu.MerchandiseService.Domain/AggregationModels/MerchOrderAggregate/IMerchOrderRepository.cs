using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    /// <summary>
    ///     Репозиторий для управления <see cref="MerchOrder" />
    /// </summary>
    public interface IMerchOrderRepository : IRepository<MerchOrder>
    {
        /// <summary>
        ///     Проверить наличие мерча
        /// </summary>
        /// <param name="skus">Список SKU</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken" /></param>
        /// <returns>Список запрошенного мерча, который есть в наличии</returns>
        Task<List<Sku>> CheckMerchItemsAsync(List<Sku> skus, CancellationToken cancellationToken = default);
    }
}