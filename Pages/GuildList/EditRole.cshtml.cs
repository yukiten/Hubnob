using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hubnob.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hubnob.Pages.GuildList
{
    public class EditRoleModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditRoleModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GuildMember GuildMember { get; set; }
        public IList<GuildRole> GuildRoles { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GuildMember = await _context.GuildMembers
                .Include(g => g.Guild)
                .Include(g => g.GuildRole)
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (GuildMember == null)
            {
                return NotFound();
            }

            GuildRoles = await _context.GuildRoles.Where(gr => gr.GuildId == GuildMember.GuildId).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GuildMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuildMemberExists(GuildMember.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ManageMembers", new { id = GuildMember.GuildId });
        }

        private bool GuildMemberExists(int id)
        {
            return _context.GuildMembers.Any(e => e.Id == id);
        }
    }
}
