using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cashrewards.Host.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator);
    }
}
