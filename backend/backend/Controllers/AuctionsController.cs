using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionService _service;
        public AuctionsController(IAuctionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var auction = _service.GetById(id);
            if (auction == null) return NotFound();

            return Ok(auction);
        }

        [HttpPost]
        public IActionResult Create(Models.Auction a)
        {
            var auction = _service.Create(a);
            return Ok(auction);
        }
    }
}
