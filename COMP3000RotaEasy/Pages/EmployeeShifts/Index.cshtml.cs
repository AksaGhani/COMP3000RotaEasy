using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using COMP3000RotaEasy.Models;

namespace COMP3000RotaEasy.Pages.EmployeeShifts
{
    public class IndexModel : PageModel
    {
        private readonly COMP3000RotaEasy.Models.COMP3000Context _context;

        public IndexModel(COMP3000RotaEasy.Models.COMP3000Context context)
        {
            _context = context;
        }

        public IList<Shifts> Shifts { get;set; }

        public async Task OnGetAsync()
        {
            Shifts = await _context.Shifts.ToListAsync();
        }
    }
}
