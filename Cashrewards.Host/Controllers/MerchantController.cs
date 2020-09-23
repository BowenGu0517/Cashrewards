using Cashrewards.Application.Commands.CreateMerchant;
using Cashrewards.Application.Commands.DeleteMerchant;
using Cashrewards.Application.Commands.UpdateMerchant;
using Cashrewards.Application.Queries.GetMerchant;
using Cashrewards.Application.Queries.GetMerchants;
using Cashrewards.Host.Infrastructure;
using Cashrewards.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Cashrewards.Host.Controllers
{
    [Route("api/merchant")]
    public class MerchantController : BaseController
    {

        [HttpGet("merchants")]
        public async Task<ActionResult<IEnumerable<MerchantViewModel>>> GetMerchants()
        {
            var request = new GetMerchantsQuery();

            var response = await Mediator.Send(request);

            return response.ToActionResult<IEnumerable<MerchantViewModel>>();
        }

        [HttpGet("merchant/{uniqueId}")]
        public async Task<ActionResult<MerchantViewModel>> GetMerchant([FromQuery][Required] string uniqueId)
        {
            var request = new GetMerchantQuery
            {
                UniqueId = uniqueId
            };

            var response = await Mediator.Send(request);

            return response.ToActionResult<MerchantViewModel>();
        }

        [HttpPost("merchant")]
        public async Task<ActionResult> CreateMerchant([FromBody][Required] CreateMerchantCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ToActionResult();
        }

        [HttpPut("merchant")]
        public async Task<ActionResult> UpdateMerchant([FromBody][Required] UpdateMerchantCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ToActionResult();
        }

        [HttpDelete("merchant/{uniqueId}")]
        public async Task<ActionResult> DeleteMerchant([FromQuery][Required] string uniqueId)
        {
            var request = new DeleteMerchantCommand
            {
                UniqueId = uniqueId
            };

            var response = await Mediator.Send(request);

            return response.ToActionResult();
        }
    }
}
