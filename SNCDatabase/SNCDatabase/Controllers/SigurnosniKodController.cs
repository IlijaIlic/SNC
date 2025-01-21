using Microsoft.AspNetCore.Mvc;
using SNCDatabase.DB; // Replace with the namespace for your DbContext
using SNCDatabase.Models; // Replace with the namespace for your models
using System.Linq;

namespace SNCDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigurnosniKodController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SigurnosniKodController(AppDbContext context)
        {
            _context = context;
        }

        // Method to check if a security code exists
        [HttpGet("{sigurnosniKod}")]
        public IActionResult CheckSigurnosniKod(int sigurnosniKod) // Change the parameter type to int
        {
            // Check if the Sigurnosni Kod exists in the database
            var sigurnosniKodEntry = _context.SigurnosniKodovi
                .FirstOrDefault(s => s.SigKod == sigurnosniKod);

            if (sigurnosniKodEntry == null)
            {
                return NotFound("Security code not found.");
            }

            // Return the found entry
            return Ok(sigurnosniKodEntry);
        }





    }
}