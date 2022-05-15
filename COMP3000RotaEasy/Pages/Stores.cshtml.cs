using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP3000RotaEasy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace COMP3000RotaEasy.Pages
{
    public class StoresModel : PageModel
    {
        private readonly COMP3000RotaEasy.Models.COMP3000Context _context; 

        public StoresModel(COMP3000RotaEasy.Models.COMP3000Context context)
        {
            _context = context;
        }

        public IList<Stores> Stores { get; set; }

        public async Task OnGetAsync()
        {
            Stores = await _context.Stores.ToListAsync();
        }
    }
}
