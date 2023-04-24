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
    public class DeleteModel : PageModel
    {
        private readonly Hubnob.Data.ApplicationDbContext _context;

        public DeleteModel(Hubnob.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Guilds == null)
            {
                return NotFound();
            }
            var guild = await _context.Guilds.FindAsync(id);

            if (guild != null)
            {
                Guild = guild;
                _context.Guilds.Remove(Guild);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
