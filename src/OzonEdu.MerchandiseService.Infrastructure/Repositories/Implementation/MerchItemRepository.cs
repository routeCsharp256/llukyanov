using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class MerchItemRepository : IMerchItemRepository
    {
        public IUnitOfWork UnitOfWork { get; }

        public Task<MerchItem> CreateAsync(MerchItem itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MerchItem> UpdateAsync(MerchItem itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<long>> ReserveMerchItem(long sku, int quantity,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}