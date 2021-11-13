using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchandiseServiceGrpcService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseServiceGrpcService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        public override async Task<MerchandiseOrderIdResponse> AskMerchandise(AskMerchandiseRequest request,
            ServerCallContext context)
        {
            var merchItems = request.MerchandiseItems
                .Select(item => new MerchItem(item.ItemId, item.ItemName, item.Quantity)).ToList();
            return new MerchandiseOrderIdResponse
            {
                OrderId = await _merchandiseService.AskMerchandise(merchItems, context.CancellationToken)
            };
        }

        public override async Task<CheckMerchandiseResponse> CheckMerchandise(MerchandiseOrderIdRequest request,
            ServerCallContext context)
        {
            return new CheckMerchandiseResponse
            {
                OrderStatus = await _merchandiseService.CheckMerchandise(request.OrderId, context.CancellationToken)
            };
        }
    }
}