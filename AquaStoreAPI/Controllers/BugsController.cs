using AquaStoreAPI.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace AquaStoreAPI.Controllers
{
    [ApiController]
    [Route("api/bugs")]
    public class BugsController : ControllerBase
    {
        private readonly StoreDbContext _dbContext;

        public BugsController(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            return NotFound(new ApiResponse(404));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequestById(int id)
        {
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
    }
}
