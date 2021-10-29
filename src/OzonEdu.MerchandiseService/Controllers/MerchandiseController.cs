using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/merch")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        [HttpPost]
        [Route("ask")]
        public async Task<ActionResult<long?>> AskMerchandise(List<MerchandiseItem> merchandiseItems,
            CancellationToken token)
        {
            return Ok(await _merchandiseService.AskMerchandise(merchandiseItems, token));
        }

        [HttpGet]
        [Route("check")]
        public async Task<ActionResult<string>> CheckMerchandise(long orderId, CancellationToken token)
        {
            return Ok(await _merchandiseService.CheckMerchandise(orderId, token));
        }
    }
}