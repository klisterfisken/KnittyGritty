using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnittyGritty.Pages.Designers
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
        public Designer Designer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designer = await _context.Designer.FirstOrDefaultAsync(m => m.DesignerID == id);

            if (designer is not null)
            {
                Designer = designer;

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

            var designer = await _context.Designer.FindAsync(id);
            if (designer != null)
            {
                Designer = designer;
                _context.Designer.Remove(Designer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
