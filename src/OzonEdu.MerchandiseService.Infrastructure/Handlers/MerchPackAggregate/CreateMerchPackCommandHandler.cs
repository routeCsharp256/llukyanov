using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class CreateMerchPackCommandHandler : IRequestHandler<CreateMerchPackRequest, CreateMerchPackResponse>
    {
        private readonly IMerchPackRepository _merchPackRepository;

        public CreateMerchPackCommandHandler(IMerchPackRepository merchPackRepository)
        {
            
            _merchPackRepository = merchPackRepository;
        }

        public async Task<CreateMerchPackResponse> Handle(CreateMerchPackRequest request,
            CancellationToken cancellationToken)
        {
            var merchPackDetails = new MerchPack(
                new Name(request.Name), 
                request.EmployeeEventId, 
                request.IsConference, 
                new List<Sku>(request.MerchItemSkus.Select(x => new Sku(x))));
            
            var newMerchPack = await _merchPackRepository.CreateAsync(merchPackDetails, cancellationToken);
            return new CreateMerchPackResponse
            {
                MerchPackId = newMerchPack.Id
            };
        }
    }
}