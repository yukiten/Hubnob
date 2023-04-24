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
    public class IndexModel : PageModel
    {
        private readonly Hubnob.Data.ApplicationDbContext _context;

        public IndexModel(Hubnob.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Guild> Guild { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Guilds != null)
            {
                Guild = await _context.Guilds
                .Include(g => g.GuildMaster).ToListAsync();
            }
        }
    }
}
