using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNCDatabase.DB;
using SNCDatabase.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SNCDatabase.Controllers
{
    [Route("mladenci")]
    [ApiController]
    public class MladenciController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MladenciController(AppDbContext context)
        {
            _context = context;
        }

        // GET: mladenci
        [HttpGet]
        public async Task<IActionResult> GetMladenci()
        {
            var mladenci = await _context.Mladenci.ToListAsync();
            return Ok(mladenci);
        }

        // GET: mladenci/{uid}
        [HttpGet("{uid}")]
        public async Task<IActionResult> GetMladenciByUID(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                return BadRequest("UID is required.");
            }

            var mladenci = await _context.Mladenci.FirstOrDefaultAsync(m => m.UID == uid);  //mladenci does not have an UID

            if (mladenci == null)
            {
                return NotFound(new { Message = $"Mladenci with UID '{uid}' not found." });
            }

            return Ok(mladenci);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMladenci([FromBody] Mladenci mladenci)
        {
            if (mladenci == null || string.IsNullOrEmpty(mladenci.Sifra))
            {
                return BadRequest("Invalid data. 'Sifra' is required.");
            }

            try
            {
                // Add the new Mladenci to the database
                var newMladenci = new Mladenci
                {
                    UID = mladenci.UID,
                    Ime = mladenci.Ime, // Ensure correct property names
                    Prezime = mladenci.Prezime, // Ensure correct property names
                    ImePartneta = mladenci.ImePartneta,
                    PrezimePartnera= mladenci.PrezimePartnera,
                    Email = mladenci.Email,
                    Sifra = mladenci.Sifra, // If you need hashed passwords, handle it here
                    BrojTelefona = mladenci.BrojTelefona
                };

                await _context.Mladenci.AddAsync(newMladenci);
                await _context.SaveChangesAsync(); // Save changes to the database

                // Create a corresponding Korisnik entry
                var korisnik = new Korisnik
                {
                    UID = newMladenci.UID,
                    Tip = "mladenci",
                    MladenciID = newMladenci.ID
                };

                await _context.Korisnici.AddAsync(korisnik);
                await _context.SaveChangesAsync();

                // Return a response indicating success
                return Ok(new
                {
                    Message = "Mladenci successfully created.",
                    Data = newMladenci
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }

    }
}