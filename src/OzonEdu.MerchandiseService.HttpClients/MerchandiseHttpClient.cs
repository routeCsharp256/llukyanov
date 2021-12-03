using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClients
{
    public interface IMerchandiseHttpClient
    {
        Task<MerchandiseOrderIdResponse> AskMerchandise(MerchandiseItemRequest merchandiseItems,
            CancellationToken token);

        Task<MerchandiseOrderStatusResponse> CheckMerchandise(MerchandiseOrderIdRequest merchandiseItems,
            CancellationToken token);
    }

    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchandiseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MerchandiseOrderIdResponse> AskMerchandise(MerchandiseItemRequest merchandiseItems,
            CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<MerchandiseOrderStatusResponse> CheckMerchandise(MerchandiseOrderIdRequest merchandiseItems,
            CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("v1/api/merch/check", token);
            return await response.Content.ReadFromJsonAsync<MerchandiseOrderStatusResponse>(cancellationToken: token);
        }
    }
}