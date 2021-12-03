using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate
{
    /// <summary>
    ///     Репозиторий для управления <see cref="MerchItem" />
    /// </summary>
    public interface IMerchItemRepository : IRepository<MerchItem>
    {
        /// <summary>
        ///     Создать резерв мерча для заказа
        /// </summary>
        /// <param name="sku">SKU мерч-итема</param>
        /// <param name="quantity">Количество мерч-итемов</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken" /></param>
        /// <returns></returns>
        Task<IEnumerable<long>> ReserveMerchItem(long sku, int quantity, CancellationToken cancellationToken = default);
    }
}