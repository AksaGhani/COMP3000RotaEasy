using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using COMP3000RotaEasy.Models;

namespace COMP3000RotaEasy.Pages.TimetableShifts
{
    public class CreateModel : PageModel
    {
        private readonly COMP3000RotaEasy.Models.COMP3000Context _context;

        public CreateModel(COMP3000RotaEasy.Models.COMP3000Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Shifts Shifts { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shifts.Add(Shifts);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
