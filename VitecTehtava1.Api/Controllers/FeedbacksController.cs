using VitecTehtava1.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VitecTehtava1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbacksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback(Feedback feedback)
        {
            try
            {
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetFeedbackById", new { id = feedback.Id}, feedback);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFeedbacks()
        {
            try
            {
                var feedbacks = await _context.Feedbacks.ToListAsync();
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetFeedbackById")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            try
            {
                var feedback = await _context.Feedbacks.FindAsync(id);

                if (feedback == null)
                {
                    return NotFound($"Feedback with ID {id} not found.");
                }
                return Ok(feedback);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] Feedback feedback)
        {
            try
            {
                if (id != feedback.Id)
                {
                    return BadRequest($"Feedback ID mismatch.");
                }

                var existingFeedback =

                    await _context.Feedbacks.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

                if (existingFeedback == null)
                {
                    return NotFound($"Feedback with ID {id} not found.");
                }

                _context.Feedbacks.Update(feedback);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                var feedback = await _context.Feedbacks.FindAsync(id);

                if (feedback == null)
                {
                    return NotFound($"Feedback with ID {id} not found.");
                }

                _context.Feedbacks.Remove(feedback);
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
