using AquaStoreAPI.Errors;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Mvc;

namespace AquaStoreAPI.Controllers
{
    [ApiController]
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public ActionResult Error(int code) 
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
