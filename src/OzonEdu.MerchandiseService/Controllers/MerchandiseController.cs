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
        [Route("ask")]
        public async Task<ActionResult<AskMerchItemResponse>> AskMerch(int employeeId, long merchItemSku,
            int quantity, int employeeEventTypeId, CancellationToken token)
        {
            var askMerchRequest = new AskMerchItemRequest
            {
                EmployeeId = employeeId,
                Sku = merchItemSku,
                Quantity = quantity,
                EmployeeEventTypeId = employeeEventTypeId
            };
            var result = await _mediator.Send(askMerchRequest, token);

            return Ok(result);
        }

        [HttpGet]
        [Route("check")]
        public async Task<ActionResult<CheckMerchItemResponse>> CheckMerch(long sku, int quantity,
            CancellationToken token)
        {
            var checkMerchRequest = new CheckMerchItemRequest
            {
                Sku = sku,
                Quantity = quantity
            };
            var result = await _mediator.Send(checkMerchRequest, token);

            return Ok(result);
        }

        [HttpPost]
        [Route("reserve")]
        public async Task<ActionResult> ReserveMerch(long sku, int quantity, CancellationToken token)
        {
            var reserveMerchRequest = new ReserveMerchItemRequest
            {
                Sku = sku,
                Quantity = quantity
            };
            var result = await _mediator.Send(reserveMerchRequest, token);

            return Ok(result);
        }

        [HttpPost]
        [Route("notify")]
        public async Task<ActionResult> NotifyEmployeeAboutMerch(int employeeId, CancellationToken token)
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