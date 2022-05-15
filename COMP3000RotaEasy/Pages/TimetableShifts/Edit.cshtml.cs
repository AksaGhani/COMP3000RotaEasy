using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP3000RotaEasy.Models;

namespace COMP3000RotaEasy.Pages.TimetableShifts
{
    public class EditModel : PageModel
    {
        private readonly COMP3000RotaEasy.Models.COMP3000Context _context;

        public EditModel(COMP3000RotaEasy.Models.COMP3000Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Shifts Shifts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shifts = await _context.Shifts.FirstOrDefaultAsync(m => m.ShiftId == id);

            if (Shifts == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shifts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftsExists(Shifts.ShiftId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShiftsExists(int id)
        {
            return _context.Shifts.Any(e => e.ShiftId == id);
        }
    }
}
