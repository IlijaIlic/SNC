using Microsoft.AspNetCore.Mvc;
using SNCDatabase.DB;

namespace SNCDatabase.Controllers
{
    [ApiController]
    [Route("poslasticari")]
    public class PoslasticarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PoslasticarController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            // Retrieve all Poslasticar data along with related SlikePoslasticara and slobodnitermini
            var data = _context.Poslasticari
                .Select(poslasticar => new
                {
                    Poslasticar = poslasticar,
                    SlobodniTermini = _context.SlobodniTermini
                        .Where(t => t.PoslasticarID == poslasticar.ID)
                        .ToList(),
                    SlikePoslasticara = _context.SlikePoslasticara
                        .Where(s => s.PoslasticarID == poslasticar.ID)
                        .ToList(),
                   
                })
                .ToList();
            if (!data.Any())
            {
                return NotFound("No Poslasticari found.");
            }



            return Ok(data);
        }

        //korisnik uid

        [HttpGet("{id}")]
        public IActionResult GetPoslasticarById(int id)
        {
            // Retrieve a single Poslasticar by ID
            var poslasticar = _context.Poslasticari.Find(id);
            if (poslasticar == null)
            {
                return NotFound();
            }

            return Ok(poslasticar);
        }
    }
}
