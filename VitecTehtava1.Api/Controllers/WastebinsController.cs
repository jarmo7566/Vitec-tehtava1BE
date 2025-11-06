using VitecTehtava1.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VitecTehtava1.Api.Controllers
{
    [Route("api/wastebins")]
    [ApiController]
    public class WastebinsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WastebinsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWastebin(Wastebin wastebin)
        {
            try
            {
                _context.Wastebins.Add(wastebin);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetWastebinById", new { id = wastebin.Id}, wastebin);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWastebins()
        {
            try
            {
                var wastebins = await _context.Wastebins.ToListAsync();
                return Ok(wastebins);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetWastebinById")]
        public async Task<IActionResult> GetWastebinById(int id)
        {
            try
            {
                var wastebin = await _context.Wastebins.FindAsync(id);

                if (wastebin == null)
                {
                    return NotFound($"Wastebin with ID {id} not found.");
                }
                return Ok(wastebin);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWastebin(int id, [FromBody] Wastebin wastebin)
        {
            try
            {
                if (id != wastebin.Id)
                {
                    return BadRequest($"Wastebin ID mismatch.");
                }

                var existingWastebin =

                    await _context.Wastebins.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

                if (existingWastebin == null)
                {
                    return NotFound($"Wastebin with ID {id} not found.");
                }

                _context.Wastebins.Update(wastebin);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWastebin(int id)
        {
            try
            {
                var wastebin = await _context.Wastebins.FindAsync(id);

                if (wastebin == null)
                {
                    return NotFound($"Wastebin with ID {id} not found.");
                }
                
                _context.Wastebins.Remove(wastebin);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
