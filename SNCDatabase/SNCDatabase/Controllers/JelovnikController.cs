using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SNCDatabase.DB;
using SNCDatabase.Models;

namespace SNCDatabase.Controllers
{

    [ApiController]
    [Route("jelovnici")]
    public class JelovnikController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JelovnikController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddJelovnik([FromBody] Jelovnik data)
        {
            try
            {
                if (data == null)
                {
                    return BadRequest("Invalid data!");
                }

                var jelo = new Jelovnik
                {
                    ImeJela = data.ImeJela,
                    Kolicina = data.Kolicina,
                    RestoranID = data.RestoranID,
                    TipJela = data.TipJela,
                    Cena = data.Cena
                };

                await _context.Jelovnici.AddAsync(jelo);
                await _context.SaveChangesAsync();

                return Ok("Jelo uspesno dodato!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetJelovnikByRestoranID(int id)
        {
            var jelo = _context.Jelovnici
                .Where(j => j.RestoranID == id)
                .ToList();
            return Ok(jelo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJeloById(int id)
        {

            _context.Jelovnici.RemoveRange(_context.Jelovnici.Where(j => j.ID == id));
            await _context.SaveChangesAsync();
            return Ok("Jelo uspesno obrisano!");
        }
    }
}
