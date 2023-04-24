using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Hubnob.Data;

namespace Hubnob.Pages.GuildList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Guild Guild { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Set the current user as the Guild Master.
            Guild.GuildMasterId = _userManager.GetUserId(User);

            // Set the CreationDate to the current date.
            Guild.CreationDate = DateTime.Now;

            _context.Guilds.Add(Guild);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
