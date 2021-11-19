using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AskMerch;
using OzonEdu.MerchandiseService.Infrastructure.Commands.CheckMerch;
using OzonEdu.MerchandiseService.Infrastructure.Commands.NotifyEmployee;
using OzonEdu.MerchandiseService.Infrastructure.Commands.ReserveMerch;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/merch")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchandiseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("reserve")]
        public async Task<ActionResult> ReserveMerch(long merchOrderId, List<long> skus, CancellationToken token)
        {
            var reserveMerchRequest = new ReserveMerchItemsRequest()
            {
                MerchOrderId = merchOrderId,
            };
            var result = await _mediator.Send(reserveMerchRequest, token);

            return Ok(result);
        }

        [HttpPost]
        [Route("notify")]
        public async Task<ActionResult> NotifyEmployeeAboutMerch(long employeeId, CancellationToken token)
        {
            var notifyEmployeeRequest = new NotifyEmployeeRequest
            {
                EmployeeId = employeeId
            };
            var result = await _mediator.Send(notifyEmployeeRequest, token);

            return Ok(result);
        }
    }
}