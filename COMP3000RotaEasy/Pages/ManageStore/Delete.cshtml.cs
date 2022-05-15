using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using COMP3000RotaEasy.Models;

namespace COMP3000RotaEasy.Pages.ManageStore
{
    public class DeleteModel : PageModel
    {
        private readonly COMP3000RotaEasy.Models.COMP3000Context _context;

        public DeleteModel(COMP3000RotaEasy.Models.COMP3000Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Stores Stores { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stores = await _context.Stores.FirstOrDefaultAsync(m => m.StoreId == id);

            if (Stores == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stores = await _context.Stores.FindAsync(id);

            if (Stores != null)
            {
                _context.Stores.Remove(Stores);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
