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
    public class ShiftsController : ControllerBase
    {
        private readonly COMP3000Context _context;

        public ShiftsController(COMP3000Context context)
        {
            _context = context;
        }

        // GET: api/Shifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shifts>>> GetShifts()
        {
            return await _context.Shifts.ToListAsync();
        }

        // GET: api/Shifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shifts>> GetShifts(int id)
        {
            var shifts = await _context.Shifts.FindAsync(id);

            if (shifts == null)
            {
                return NotFound();
            }

            return shifts;
        }

        // PUT: api/Shifts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShifts(int id, Shifts shifts)
        {
            if (id != shifts.ShiftId)
            {
                return BadRequest();
            }

            _context.Entry(shifts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftsExists(id))
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

        // POST: api/Shifts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shifts>> PostShifts(Shifts shifts)
        {
            _context.Shifts.Add(shifts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShifts", new { id = shifts.ShiftId }, shifts);
        }

        // DELETE: api/Shifts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shifts>> DeleteShifts(int id)
        {
            var shifts = await _context.Shifts.FindAsync(id);
            if (shifts == null)
            {
                return NotFound();
            }

            _context.Shifts.Remove(shifts);
            await _context.SaveChangesAsync();

            return shifts;
        }

        private bool ShiftsExists(int id)
        {
            return _context.Shifts.Any(e => e.ShiftId == id);
        }
    }
}
