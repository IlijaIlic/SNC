using Microsoft.AspNetCore.Mvc;
using SNCDatabase.DB;
using SNCDatabase.Models;

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
            //treba da vraca i ocene i da sracuna prosecnu i da je stavi ovde
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
                      Torte = _context.Torte
                .Where(t => t.PoslasticarID == poslasticar.ID)
                .ToList(),
                ProsecnaOcena = _context.OceneDekorateri
                    .Where(o => o.DekoraterID == poslasticar.ID)
                    .Average(o => (double?)o.Ocena) ?? 0.0 // Calculate average rating, default to 0.0
                  })
                 .ToList();

            if (!data.Any())
            {
                return NotFound("No Poslasticari found.");
            }



            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> AddPoslasticar([FromBody] Poslasticar poslasticarData)
        {
            try
            {
                // Validate the provided data
                if (poslasticarData == null)
                {
                    return BadRequest("Invalid data.");
                }

                // Insert the new Fotograf into the database
                var newPoslasticar = new Poslasticar
                {
                    UID = poslasticarData.UID,
                    SigurnosniKod = poslasticarData.SigurnosniKod,
                    Naziv = poslasticarData.Naziv, // Correct property name
                    Opis = poslasticarData.Opis, // Correct property name
                    Email = poslasticarData.Email,
                    Sifra = poslasticarData.Sifra, // If you need a hashed password, handle it here  nema
                    Lokacija = poslasticarData.Lokacija,
                    Cena = poslasticarData.Cena, // Correct property name
                    DatumOsnivanja = poslasticarData.DatumOsnivanja, // Correct property name
                    Ocena = 0.0f, // Default to 0 if not provided
                    BrojTelefona = poslasticarData.BrojTelefona, // Correct property name
                    



                };

                // Add the new Fotograf to the database context
                await _context.Poslasticari.AddAsync(newPoslasticar);
                await _context.SaveChangesAsync(); // Save changes to the database

                var korisnik = new Korisnik
                {
                    UID = newPoslasticar.UID,
                    Tip = "poslasticar",
                    PoslasticarID = newPoslasticar.ID

                };

                await _context.Korisnici.AddAsync(korisnik);
                await _context.SaveChangesAsync();

                // Return a response indicating the Fotograf was added successfully
                return Ok(new { message = "Poslasticar added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error occurred: {ex.Message}" });
            }
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

        [HttpGet("prekouid/{uid}")]
        public IActionResult GetPoslasticarByUid(string uid)
        {
            // Retrieve the Poslasticar using the provided UID
            var poslasticar = _context.Poslasticari.FirstOrDefault(p => p.UID == uid);
            if (poslasticar == null)
            {
                return NotFound($"No Poslasticar found with UID: {uid}");
            }

            // Gather related data and calculate the average rating
            var result = new
            {
                Poslasticar = poslasticar,
                SlobodniTermini = _context.SlobodniTermini
                    .Where(t => t.PoslasticarID == poslasticar.ID)
                    .ToList(),
                SlikePoslasticara = _context.SlikePoslasticara
                    .Where(s => s.PoslasticarID == poslasticar.ID)
                    .ToList(),
                Torte = _context.Torte
                    .Where(t => t.PoslasticarID == poslasticar.ID)
                    .ToList(),
                ProsecnaOcena = _context.OceneDekorateri
                    .Where(o => o.DekoraterID == poslasticar.ID)
                    .Average(o => (double?)o.Ocena) ?? 0.0 // Calculate average rating, default to 0.0
            };

            return Ok(result);
        }

        [HttpGet("korisnikuid/{korisnikUid}")]
        public IActionResult GetPoslasticariForKorisnikUID(string korisnikUid)
        {
            try
            {
                // Retrieve all Poslasticari along with related data and calculate if liked by the user
                var poslasticari = _context.Poslasticari
                    .Select(poslasticar => new
                    {
                        Poslasticar = poslasticar,
                        SlobodniTermini = _context.SlobodniTermini
                            .Where(t => t.PoslasticarID == poslasticar.ID)
                            .ToList(),
                        SlikePoslasticara = _context.SlikePoslasticara
                            .Where(s => s.PoslasticarID == poslasticar.ID)
                            .ToList(),
                        Torte = _context.Torte
                            .Where(t => t.PoslasticarID == poslasticar.ID)
                            .ToList(),
                        ProsecnaOcena = _context.OceneDekorateri
                            .Where(o => o.DekoraterID == poslasticar.ID)
                            .Average(o => (double?)o.Ocena) ?? 0.0, // Calculate average rating, default to 0.0
                        Liked = _context.SacuvaniPoslasticari
                            .Any(sp => sp.UID == korisnikUid && sp.PoslasticarID == poslasticar.ID) // Check if liked
                    })
                    .ToList();

                if (!poslasticari.Any())
                {
                    return NotFound("No Poslasticari found.");
                }

                return Ok(poslasticari);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error occurred: {ex.Message}" });
            }
        }



    }
}
