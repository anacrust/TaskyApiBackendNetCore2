using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskyApi.Models;
using TaskyApi.Models.DTOs;

namespace TaskyApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Taskies")]
    public class TaskiesController : Controller
    {
        private readonly DevContext _context;

        public TaskiesController(DevContext context)
        {
            _context = context;
        }

        // GET: api/Taskies
        [HttpGet]
        public IEnumerable<Tasky> GetTasky()
        {
            return _context.Tasky;
        }

        // GET: api/Taskies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasky([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tasky = await _context.Tasky
                //.Include(t => t.Creator)
                //.Include(t => t.Tasker)
                //.Include(t => t.TaskType)
                //.Include(t => t.PaymentType)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (tasky == null)
            {
                return NotFound();
            }

            return Ok(tasky);
        }

        // PUT: api/Taskies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasky([FromRoute] Guid id, [FromBody] Tasky tasky)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tasky.Id)
            {
                return BadRequest();
            }

            _context.Entry(tasky).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Taskies
        [HttpPost]
        public async Task<IActionResult> PostTasky([FromBody] TaskyDto tasky)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tasky.Add(tasky);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasky", new { id = tasky.Id }, tasky);
        }

        // DELETE: api/Taskies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasky([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tasky = await _context.Tasky.SingleOrDefaultAsync(m => m.Id == id);
            if (tasky == null)
            {
                return NotFound();
            }

            _context.Tasky.Remove(tasky);
            await _context.SaveChangesAsync();

            return Ok(tasky);
        }

        private bool TaskyExists(Guid id)
        {
            return _context.Tasky.Any(e => e.Id == id);
        }
    }
}