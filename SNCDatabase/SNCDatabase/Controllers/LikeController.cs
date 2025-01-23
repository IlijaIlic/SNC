using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNCDatabase.DB;
using SNCDatabase.Models;

namespace SNCDatabase.Controllers
{
    [Route("like/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {

        private readonly AppDbContext _context;

        public LikeController(AppDbContext context)
        {
            _context = context;
        }

        //NE ZNAM STA VRACA za TYPE TO MORA DA SE POGLEDA NE SECAM SE
        [HttpPost("addLikedEntity")]
        public async Task<IActionResult> AddLikedEntity([FromBody] dynamic requestData)
        {
            string uid = requestData.UID;
            string type = requestData.Type;
            int entityId = requestData.EntityID;

            try
            {
                if (type == "dekorater")
                {
                    var newEntity = new SacuvanDekorater
                    {
                        UID = uid,
                        DekoraterID = entityId
                    };
                    await _context.SacuvaniDekorateri.AddAsync(newEntity);
                }
                else if (type == "fotograf")
                {
                    var newEntity = new SacuvanFotograf
                    {
                        UID = uid,
                        FotografID = entityId
                    };
                    await _context.SacuvaniFotografi.AddAsync(newEntity);
                }
                else if (type == "poslasticar")
                {
                    var newEntity = new SacuvanPoslasticar
                    {
                        UID = uid,
                        PoslasticarID = entityId
                    };
                    await _context.SacuvaniPoslasticari.AddAsync(newEntity);
                }
                else if (type == "restoran")
                {
                    var newEntity = new SacuvanRestoran
                    {
                        UID = uid,
                        RestoranID = entityId
                    };
                    await _context.SacuvaniRestorani.AddAsync(newEntity);
                }
                else
                {
                    return BadRequest(new { message = "Invalid type specified." });
                }

                await _context.SaveChangesAsync();
                return Ok(new { message = "Entity added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error occurred: {ex.Message}" });
            }
        }

        [HttpPost("deleteLikedEntity")]
        public async Task<IActionResult> DeleteLikedEntity([FromBody] dynamic requestData)
        {
            string uid = requestData.UID;
            string type = requestData.Type;
            int entityId = requestData.EntityID;

            try
            {
                if (type == "dekorater")
                {
                    var entity = _context.SacuvaniDekorateri
                        .FirstOrDefault(e => e.UID == uid && e.DekoraterID == entityId);

                    if (entity != null)
                    {
                        _context.SacuvaniDekorateri.Remove(entity);
                    }
                }
                else if (type == "fotograf")
                {
                    var entity = _context.SacuvaniFotografi
                        .FirstOrDefault(e => e.UID == uid && e.FotografID == entityId);

                    if (entity != null)
                    {
                        _context.SacuvaniFotografi.Remove(entity);
                    }
                }
                else if (type == "poslasticar")
                {
                    var entity = _context.SacuvaniPoslasticari
                        .FirstOrDefault(e => e.UID == uid && e.PoslasticarID == entityId);

                    if (entity != null)
                    {
                        _context.SacuvaniPoslasticari.Remove(entity);
                    }
                }
                else if (type == "restoran")
                {
                    var entity = _context.SacuvaniRestorani
                        .FirstOrDefault(e => e.UID == uid && e.RestoranID == entityId);

                    if (entity != null)
                    {
                        _context.SacuvaniRestorani.Remove(entity);
                    }
                }
                else
                {
                    return BadRequest(new { message = "Invalid type specified." });
                }

                await _context.SaveChangesAsync();
                return Ok(new { message = "Entity deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error occurred: {ex.Message}" });
            }
        }

    }
}
