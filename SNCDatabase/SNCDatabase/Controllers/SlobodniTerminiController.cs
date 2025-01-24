using Microsoft.AspNetCore.Mvc;
using SNCDatabase.DB;
using SNCDatabase.Models;

namespace SNCDatabase.Controllers
{
    [ApiController]
    [Route("slobodnitermini")]
    public class SlobodniTerminiController : ControllerBase
    {

        private readonly AppDbContext _context;

        public SlobodniTerminiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("restorani")]
        public async Task<IActionResult> AddRestoranSlobodanTermin([FromBody] SlobodanTermin data)
        {
            if (data == null)
            {
                return BadRequest("Bad request");
            }

            var restoran = _context.Restorani.Find(data.RestoranID);

            if (restoran == null)
            {
                return NotFound("Restoran not found");
            }

            var sT = new SlobodanTermin
            {
                RestoranID = data.RestoranID,
                Termin = data.Termin
            };

            await _context.SlobodniTermini.AddAsync(sT);
            await _context.SaveChangesAsync();

            return Ok(sT);
        }
    }
}
