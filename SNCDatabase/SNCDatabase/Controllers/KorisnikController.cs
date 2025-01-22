using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNCDatabase.DB;

namespace SNCDatabase.Controllers
{
    [ApiController]
    [Route("korisnici")]
    public class KorisnikController : ControllerBase
    {

        private readonly AppDbContext _context;

        public KorisnikController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{uid}")]
        public async Task<IActionResult> GetKorisnikByUID(string uid)
        {
            var korisnik = await _context.Korisnici
                .FirstOrDefaultAsync(k => k.UID == uid);
            if (korisnik == null)
            {
                return BadRequest("Korisnik nije pronadjen.");
            }
            return Ok(korisnik);
        }

    }
}
