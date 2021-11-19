using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    /// <summary>
    ///     Репозиторий для управления <see cref="MerchItem" />
    /// </summary>
    public interface IMerchItemRepository : IRepository<MerchItem>
    {
    }
}