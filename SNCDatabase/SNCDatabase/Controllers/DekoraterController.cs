using Microsoft.AspNetCore.Mvc;
using SNCDatabase.DB;
using SNCDatabase.Models;

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

        [HttpPost]
        public async Task<IActionResult> AddDekorater([FromBody] Dekorater data)
        {
            try
            {
                if (data == null)
                {
                    return BadRequest("Invalid data.");
                }

                var dekorater = new Dekorater
                {
                    UID = data.UID,
                    SigurnosniKod = data.SigurnosniKod,
                    Naziv = data.Naziv,
                    Opis = data.Opis,
                    Email = data.Email,
                    Sifra = data.Sifra,
                    Lokacija = data.Lokacija,
                    Cena = data.Cena,
                    DatumOsnivanja = data.DatumOsnivanja,
                    BrojTelefona = data.BrojTelefona,
                    Ocena = 0.0f
                };

                await _context.Dekorateri.AddAsync(dekorater);
                await _context.SaveChangesAsync();


                var korisnik = new Korisnik
                {
                    UID = dekorater.UID,
                    Tip = "dekorater",
                    DekoraterID = dekorater.ID

                };

                await _context.Korisnici.AddAsync(korisnik);
                await _context.SaveChangesAsync();

                return Ok("Dekorater uspesno dodat");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
