using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly IAuctionService _service;

        public BidsController(IAuctionService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddBid(Models.Bid b)
        {
            var bid = _service.AddBid(b);

            if (bid == null)
                return BadRequest("Invalid bid");

            return Ok(bid);

        }
    }
}
