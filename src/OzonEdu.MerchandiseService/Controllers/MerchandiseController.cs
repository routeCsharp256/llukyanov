using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [Route("orders/manually")]
        public async Task<ActionResult> CreateOrderManually(string employeeEmail, List<long> skus, int priority,
            CancellationToken token)
        {
            var createOrderManuallyRequest = new CreateOrderManuallyRequest
            {
                EmployeeEmail = employeeEmail,
                Skus = skus,
                Priority = priority
            };
            var result = await _mediator.Send(createOrderManuallyRequest, token);

            return Ok(result);
        }

        [HttpPost]
        [Route("orders/by-pack")]
        public async Task<ActionResult> CreateOrderByPack(string employeeEmail, int employeeEventId, int merchPackId,
            int priority, CancellationToken token)
        {
            var createOrderByPackRequest = new CreateOrderByPackRequest
            {
                EmployeeEmail = employeeEmail,
                EmployeeEventId = employeeEventId,
                MerchPackId = merchPackId,
                Priority = priority
            };
            var result = await _mediator.Send(createOrderByPackRequest, token);

            return Ok(result);
        }

        [HttpPost]
        [Route("pack")]
        public async Task<ActionResult> CreateMerchPack(string name, int employeeEventId, bool isConference,
            List<long> merchItemSkus, CancellationToken token)
        {
            var createMerchPackRequest = new CreateMerchPackRequest
            {
                Name = name,
                EmployeeEventId = employeeEventId,
                IsConference = isConference,
                MerchItemSkus = merchItemSkus,
            };
            var result = await _mediator.Send(createMerchPackRequest, token);

            return Ok(result);
        }

        [HttpPost]
        [Route("orders/manager")]
        public async Task<ActionResult> AssignManager(int orderId, int managerId, CancellationToken token)
        {
            var createOrderByPackRequest = new AssignManagerRequest
            {
                OrderId = orderId,
                ManagerId = managerId
            };
            var result = await _mediator.Send(createOrderByPackRequest, token);

            return Ok(result);
        }

        [HttpGet]
        [Route("orders/{orderId:long}")]
        public async Task<ActionResult> GetOrderById([FromRoute] long orderId, CancellationToken token)
        {
            var getOrderById = new GetOrderByIdRequest
            {
                OrderId = orderId
            };
            var result = await _mediator.Send(getOrderById, token);

            return Ok(result);
        }

        [HttpGet]
        [Route("orders/employee/{employeeId:int}")]
        public async Task<ActionResult> GetOrdersByEmployeeId([FromRoute] int employeeId, CancellationToken token)
        {
            var getOrdersByEmployeeId = new GetOrdersByEmployeeIdRequest
            {
                EmployeeId = employeeId
            };
            var result = await _mediator.Send(getOrdersByEmployeeId, token);

            return Ok(result);
        }

        [HttpPost]
        [Route("employee/notification")]
        public async Task<ActionResult> NotifyEmployeeAboutMerch(string employeeEmail, CancellationToken token)
        {
            var notifyEmployeeRequest = new NotifyEmployeeRequest
            {
                EmployeeEmail = employeeEmail
            };
            var result = await _mediator.Send(notifyEmployeeRequest, token);

            return Ok(result);
        }
    }
}