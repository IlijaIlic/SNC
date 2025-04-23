using Microsoft.AspNetCore.Mvc;
using SNCDatabase.DB;
using SNCDatabase.Models;

namespace SNCDatabase.Controllers
{
    [ApiController]
    [Route("zakazano")]
    public class ZakazanoController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ZakazanoController(AppDbContext context)
        {
            _context = context;
        }

        public class ZakaznoPrekoRestorana
        {
            public DateTime retoranTermin;
            public int restoranID;
            public int cenaRestorana;
            public int mladenciID;
        }

        public class ZakazanoRestoran
        {
            public float CenaRestorana;
            public DateTime RestoranTermin;
            public int RestoranID;
            public int MladenciID;
        }

        [HttpPost("restoran")]
        public async Task<IActionResult> AddZakazanoPrekoRestorana([FromBody] ZakaznoPrekoRestorana data)
        {
            if (data == null)
            {
                return BadRequest("Invalid data provided.");
            }

            


            // Retrieve the restoran
            var zakazano = _context.Zakazano
                .FirstOrDefault(m => m.MladenciID == data.mladenciID);

            if (zakazano == null)
            {
                var zkz = new Zakazano
                {
                    CenaRestorana = data.cenaRestorana,
                    RestoranTermin = data.retoranTermin,
                    RestoranID = data.restoranID,
                    MladenciID = data.mladenciID
                };

                await _context.Zakazano.AddAsync(zkz);

                await _context.SaveChangesAsync();
                return Ok("Zakazano successfully added.");
            }
            else
            {
              
                zakazano.CenaRestorana = data.cenaRestorana;
                zakazano.RestoranTermin = data.retoranTermin;
                zakazano.RestoranID = data.restoranID;

                await _context.SaveChangesAsync();
                return Ok("Zakazano successfully updated.");
            }
        }
    }
}
