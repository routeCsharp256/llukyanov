using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public Task<long> AskMerchandise(List<MerchandiseItem> merchandiseItems, CancellationToken _)
        {
            return Task.FromResult((long) 227);
        }

        public Task<string> CheckMerchandise(long orderId, CancellationToken _)
        {
            return Task.FromResult(Status.Pending.ToString());
        }
    }
}