using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<long> AskMerchandise(List<MerchItem> merchandiseItems, CancellationToken _);

        Task<string> CheckMerchandise(long orderId, CancellationToken _);
    }
}