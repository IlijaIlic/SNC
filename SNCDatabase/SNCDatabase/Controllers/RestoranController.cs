    using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SNCDatabase.DB;
using SNCDatabase.Models;

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

        [HttpPost]
        public async Task<IActionResult> AddRestoran([FromBody] Restoran data)
        {
            try
            {
                if (data == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid data: " + JsonConvert.SerializeObject(data));
                }

                var restoran = new Restoran
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
                    PraviTortu = data.PraviTortu,
                    Ocena = 0.0f,
                };

                await _context.Restorani.AddAsync(restoran);
                await _context.SaveChangesAsync();

                var korisnik = new Korisnik
                {
                    UID = restoran.UID,
                    Tip = "restoran",
                    RestoranID = restoran.ID

                };

                await _context.Korisnici.AddAsync(korisnik);
                await _context.SaveChangesAsync();

                return Ok(restoran);
            }
            catch (Exception e)
            {
                return BadRequest("Error: " + e.Message);
            }

        }
    }
}
