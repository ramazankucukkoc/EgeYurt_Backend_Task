using EgeYurt_Backend_Task.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EgeYurt_Backend_Task.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;

        protected int getUserIdFromRequest()
        {
            int userId = HttpContext.User.GetUserId();
            return userId;
        }
    }
}
