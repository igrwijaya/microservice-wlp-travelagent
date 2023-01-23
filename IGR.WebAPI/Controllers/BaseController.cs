using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IGR.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        #region Constructors

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        #endregion

        #region Protected Properties

        protected IMediator  Mediator { get; }

        #endregion
    }
}