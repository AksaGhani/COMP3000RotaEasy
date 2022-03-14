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
    public class HolidaysController : ControllerBase
    {
        private readonly COMP3000Context _context;

        public HolidaysController(COMP3000Context context)
        {
            _context = context;
        }

        // GET: api/Holidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holidays>>> GetHolidays()
        {
            return await _context.Holidays.ToListAsync();
        }

        // GET: api/Holidays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Holidays>> GetHolidays(int id)
        {
            var holidays = await _context.Holidays.FindAsync(id);

            if (holidays == null)
            {
                return NotFound();
            }

            return holidays;
        }

        // PUT: api/Holidays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolidays(int id, Holidays holidays)
        {
            if (id != holidays.HolidayId)
            {
                return BadRequest();
            }

            _context.Entry(holidays).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidaysExists(id))
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

        // POST: api/Holidays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Holidays>> PostHolidays(Holidays holidays)
        {
            _context.Holidays.Add(holidays);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHolidays", new { id = holidays.HolidayId }, holidays);
        }

        // DELETE: api/Holidays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Holidays>> DeleteHolidays(int id)
        {
            var holidays = await _context.Holidays.FindAsync(id);
            if (holidays == null)
            {
                return NotFound();
            }

            _context.Holidays.Remove(holidays);
            await _context.SaveChangesAsync();

            return holidays;
        }

        private bool HolidaysExists(int id)
        {
            return _context.Holidays.Any(e => e.HolidayId == id);
        }
    }
}
