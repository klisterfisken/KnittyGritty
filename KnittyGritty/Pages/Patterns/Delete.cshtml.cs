using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnittyGritty.Pages.Patterns
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public DeleteModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pattern Pattern { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pattern = await _context.Pattern.FirstOrDefaultAsync(m => m.PatternID == id);

            if (pattern is not null)
            {
                Pattern = pattern;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pattern = await _context.Pattern.FindAsync(id);
            if (pattern != null)
            {
                Pattern = pattern;
                _context.Pattern.Remove(Pattern);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
