    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("prekoid/{id}")]
        public IActionResult GetRestoranById(int id)
        {
            var restoran = _context.Restorani.Find(id);

            if (restoran == null)
            {
                return NotFound("Restoran not found");
            }

            return Ok(restoran);
        }

        [HttpGet("prekouid/{uid}")]
        public IActionResult GetRestoranByUID(string uid)
        {
            if(string.IsNullOrEmpty(uid))
            {
                return BadRequest("UID is required.");
            }

            var restoran = _context.Restorani
                   .Where(r => r.UID == uid)
                   .Select(r => new
                   {
                       Restoran = r,
                       SlikeRestoran = _context.SlikeRestorana
                           .Where(s => s.RestoranID == r.ID)
                           .ToList(),
                       SlobodniTermini = _context.SlobodniTermini
                           .Where(st => st.RestoranID == r.ID)
                           .ToList(),
                       ProsecnaOcena = _context.OceneRestorani
                           .Where(o => o.RestoranID == r.ID)
                           .Average(o => (double?)o.Ocena) ?? 0.0,
                       Zakazano = _context.Zakazano
                            .Where(z=> z.RestoranID == r.ID)
                            .ToList(),
                   })
                   .FirstOrDefault();

            if (restoran == null)
            {
                return NotFound("Restoran not found");
            }
            return Ok(restoran);
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
                    Ocena = 0.0f,
                    BrojTelefona = data.BrojTelefona,
                    PraviTortu = data.PraviTortu,
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

                return Ok("Restoran uspesno dodat");
            }
            catch (Exception e)
            {
                return BadRequest("Error: " + e.Message);
            }

        }

        [HttpPut("prekouid")]
        public async Task<IActionResult> UpdateRestoran([FromBody] Restoran data)
        {
            try
            {
                if (data == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid data: " + JsonConvert.SerializeObject(data));
                }

                var restoran = await _context.Restorani.FirstOrDefaultAsync(r => r.UID == data.UID);

                if (restoran == null)
                {
                    Console.WriteLine($"No restoran found with UID: {data.UID}");
                    return NotFound("Restoran not found");
                }
                restoran.Naziv = data.Naziv;
                restoran.Opis = data.Opis;
                restoran.Cena = data.Cena;
                restoran.BrojTelefona = data.BrojTelefona;
                restoran.PraviTortu = data.PraviTortu;
                restoran.SigurnosniKod = restoran.SigurnosniKod;

                await _context.SaveChangesAsync();
                return Ok("Restoran uspesno azuriran");
            }
            catch (Exception e)
            {
                return BadRequest("Error: " + e.Message);
            }
        }
    }
}
