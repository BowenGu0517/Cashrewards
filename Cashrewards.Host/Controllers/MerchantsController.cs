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
    public class MerchantsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MerchantViewModel>>> GetMerchants()
        {
            var request = new GetMerchantsQuery();

            var response = await Mediator.Send(request);

            return response.ToActionResult<IEnumerable<MerchantViewModel>>();
        }

        [HttpGet("{uniqueId}")]
        public async Task<ActionResult<MerchantViewModel>> GetMerchant([FromRoute][Required] string uniqueId)
        {
            var request = new GetMerchantQuery
            {
                UniqueId = uniqueId
            };

            var response = await Mediator.Send(request);

            return response.ToActionResult<MerchantViewModel>();
        }

        [HttpPost]
        public async Task<ActionResult> CreateMerchant([FromBody][Required] CreateMerchantCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ToActionResult();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMerchant([FromBody][Required] UpdateMerchantCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ToActionResult();
        }

        [HttpDelete("{uniqueId}")]
        public async Task<ActionResult> DeleteMerchant([FromRoute][Required] string uniqueId)
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
