using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hubnob.Data;

namespace Hubnob.Pages.GuildList
{
    public class DetailsModel : PageModel
    {
        private readonly Hubnob.Data.ApplicationDbContext _context;

        public DetailsModel(Hubnob.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Guild Guild { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Guilds == null)
            {
                return NotFound();
            }

            var guild = await _context.Guilds.FirstOrDefaultAsync(m => m.Id == id);
            if (guild == null)
            {
                return NotFound();
            }
            else 
            {
                Guild = guild;
            }
            return Page();
        }
    }
}
