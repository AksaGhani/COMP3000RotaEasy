using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP3000RotaEasy.Models;

namespace COMP3000RotaEasy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SickdaysController : ControllerBase
    {
        private readonly COMP3000Context _context;

        public SickdaysController(COMP3000Context context)
        {
            _context = context;
        }

        // GET: api/Sickdays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sickdays>>> GetSickdays()
        {
            return await _context.Sickdays.ToListAsync();
        }

        // GET: api/Sickdays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sickdays>> GetSickdays(int id)
        {
            var sickdays = await _context.Sickdays.FindAsync(id);

            if (sickdays == null)
            {
                return NotFound();
            }

            return sickdays;
        }

        // PUT: api/Sickdays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSickdays(int id, Sickdays sickdays)
        {
            if (id != sickdays.SickdayId)
            {
                return BadRequest();
            }

            _context.Entry(sickdays).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SickdaysExists(id))
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

        // POST: api/Sickdays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sickdays>> PostSickdays(Sickdays sickdays)
        {
            _context.Sickdays.Add(sickdays);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSickdays", new { id = sickdays.SickdayId }, sickdays);
        }

        // DELETE: api/Sickdays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sickdays>> DeleteSickdays(int id)
        {
            var sickdays = await _context.Sickdays.FindAsync(id);
            if (sickdays == null)
            {
                return NotFound();
            }

            _context.Sickdays.Remove(sickdays);
            await _context.SaveChangesAsync();

            return sickdays;
        }

        private bool SickdaysExists(int id)
        {
            return _context.Sickdays.Any(e => e.SickdayId == id);
        }
    }
}
