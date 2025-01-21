    using Microsoft.AspNetCore.Mvc;
    using SNCDatabase.DB;

namespace SNCDatabase.Controllers
{

    [ApiController]
    [Route("restorani")]
    public class RestoranController : ControllerBase
    {

        private readonly AppDbContext _context;

        public RestoranController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllRestorani()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetRestoranById(int id)
        {
            return Ok();
        }




    }
}
