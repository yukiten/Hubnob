using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hubnob.Data;

namespace Hubnob.Pages.GuildList
{
    public class EditModel : PageModel
    {
        private readonly Hubnob.Data.ApplicationDbContext _context;

        public EditModel(Hubnob.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guild Guild { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Guilds == null)
            {
                return NotFound();
            }

            var guild =  await _context.Guilds.FirstOrDefaultAsync(m => m.Id == id);
            if (guild == null)
            {
                return NotFound();
            }
            Guild = guild;
           ViewData["GuildMasterId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Guild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuildExists(Guild.Id))
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

        private bool GuildExists(int id)
        {
          return _context.Guilds.Any(e => e.Id == id);
        }
    }
}
