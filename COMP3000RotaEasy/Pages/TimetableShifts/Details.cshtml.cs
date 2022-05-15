using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using COMP3000RotaEasy.Models;

namespace COMP3000RotaEasy.Pages.TimetableShifts
{
    public class DetailsModel : PageModel
    {
        private readonly COMP3000RotaEasy.Models.COMP3000Context _context;

        public DetailsModel(COMP3000RotaEasy.Models.COMP3000Context context)
        {
            _context = context;
        }

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
    }
}
