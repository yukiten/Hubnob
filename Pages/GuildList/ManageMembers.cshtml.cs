using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hubnob.Data;

namespace Hubnob.Pages.GuildList
{
    public class ManageMembersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ManageMembersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Guild Guild { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Guild = await _context.Guilds
                .Include(g => g.GuildMembers)
                    .ThenInclude(gm => gm.User)
                .Include(g => g.GuildMembers)
                    .ThenInclude(gm => gm.GuildRole)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (Guild == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
