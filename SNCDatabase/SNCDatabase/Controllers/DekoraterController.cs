using Microsoft.AspNetCore.Mvc;
using SNCDatabase.DB;

namespace SNCDatabase.Controllers
{

    [ApiController]
    [Route("dekorateri")]
    public class DekoraterController : ControllerBase
    {

        private readonly AppDbContext _context;

        public DekoraterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllDekorateri()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetDekoraterById(int id)
        {
            return Ok();
        }
    }
}
