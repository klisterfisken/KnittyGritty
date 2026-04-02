using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnittyGritty.Pages.Yarns
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
        public Yarn Yarn { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yarn = await _context.Yarn.FirstOrDefaultAsync(m => m.YarnID == id);

            if (yarn is not null)
            {
                Yarn = yarn;

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

            var yarn = await _context.Yarn.FindAsync(id);
            if (yarn != null)
            {
                Yarn = yarn;
                _context.Yarn.Remove(Yarn);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
