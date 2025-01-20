using Microsoft.AspNetCore.Mvc;
using SNCDatabase.DB;

namespace SNCDatabase.Controllers
{
    [ApiController]
    [Route("fotografi")]
    public class FotografiController : ControllerBase
    {
        private readonly AppDbContext _context;


        public FotografiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            // Retrieve all Fotograf data along with the related SlobodniTermini
            var data = _context.Fotografi
                .Select(fotograf => new
                {
                    Fotograf = fotograf,
                    SlobodniTermini = _context.SlobodniTermini
                        .Where(s => s.FotografID == fotograf.ID)
                        .ToList()
                })
                .ToList();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetFotografById(int id)
        {
            var fotograf = _context.Fotografi.Find(id);
            if(fotograf == null)
            {
                return NotFound();
            }
            return Ok(fotograf);
        }


    }
}
