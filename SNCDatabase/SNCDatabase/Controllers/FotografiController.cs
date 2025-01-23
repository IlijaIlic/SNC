using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SNCDatabase.DB;
using SNCDatabase.Models;

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
            //treba da vraca i ocene i da sracuna prosecnu i da je stavi ovde
            var data = _context.Fotografi
                .Select(fotograf => new
                {
                    Fotograf = fotograf,
                    SlikeFotografa = _context.SlikeFotografa
                    .Where(s => s.FotografID == fotograf.ID)
                    .ToList(),
                    SlobodniTermini = _context.SlobodniTermini
                        .Where(s => s.FotografID == fotograf.ID)
                        .ToList(),
                    ProsecnaOcena = _context.OceneFotografi
                            .Where(o => o.FotografID == fotograf.ID)
                            .Average(o => (double?)o.Ocena) ?? 0.0 // Calculate average rating, default to 0.0
                })
                .ToList();

            return Ok(data);
        }

        //korisnik uid

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

        [HttpGet("prekouid/{uid}")]
        public IActionResult GetFotografByUID(string uid)
        {
            try
            {
                // Find the Fotograf by UID
                var fotograf = _context.Fotografi
                    .Where(f => f.UID == uid)
                    .Select(f => new
                    {
                        Fotograf = f,
                        SlikeFotografa = _context.SlikeFotografa
                            .Where(s => s.FotografID == f.ID)
                            .ToList(),
                        SlobodniTermini = _context.SlobodniTermini
                            .Where(s => s.FotografID == f.ID)
                            .ToList(),
                        ProsecnaOcena = _context.OceneFotografi
                            .Where(o => o.FotografID == f.ID)
                            .Average(o => (double?)o.Ocena) ?? 0.0 // Calculate average rating, default to 0.0
                    })
                    .FirstOrDefault();

                if (fotograf == null)
                {
                    return NotFound(new { message = "Fotograf with the specified UID not found." });
                }

                return Ok(fotograf);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error occurred: {ex.Message}" });
            }
        }



        [HttpPost]
        public async Task<IActionResult> AddFotograf([FromBody] Fotograf fotografData)
        {
            try
            {
                // Validate the provided data
                if (fotografData == null)
                {
                    return BadRequest("Invalid data.");
                }

                // Insert the new Fotograf into the database
                var newFotograf = new Fotograf
                {
                    UID = fotografData.UID,
                    SigurnosniKod = fotografData.SigurnosniKod,
                    Naziv = fotografData.Naziv, // Correct property name
                    Opis = fotografData.Opis, // Correct property name
                    Email = fotografData.Email,
                    Sifra = fotografData.Sifra, // If you need a hashed password, handle it here  nema
                    Lokacija = fotografData.Lokacija,
                    Cena = fotografData.Cena, // Correct property name
                    DatumOsnivanja = fotografData.DatumOsnivanja, // Correct property name
                    Ocena = 0.0f, // Default to 0 if not provided
                    BrojTelefona = fotografData.BrojTelefona, // Correct property name
                    CenaPoSlici = fotografData.CenaPoSlici // Correct property name


                  
                };

                // Add the new Fotograf to the database context
                await _context.Fotografi.AddAsync(newFotograf);
                await _context.SaveChangesAsync(); // Save changes to the database

                var korisnik = new Korisnik
                {
                    UID = newFotograf.UID,
                    Tip = "fotograf",
                    FotografID = newFotograf.ID

                };

                await _context.Korisnici.AddAsync(korisnik);
                await _context.SaveChangesAsync();

                // Return a response indicating the Fotograf was added successfully
                return Ok(new { message = "Fotograf added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error occurred: {ex.Message}" });
            }
        }


    }
}
