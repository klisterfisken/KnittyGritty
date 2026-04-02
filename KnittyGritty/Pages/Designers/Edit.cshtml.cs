using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnittyGritty.Pages.Designers
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public EditModel(KnittyGrittyContext context)
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

            var designer =  await _context.Designer.FirstOrDefaultAsync(m => m.DesignerID == id);
            if (designer == null)
            {
                return NotFound();
            }
            Designer = designer;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Designer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignerExists(Designer.DesignerID))
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

        private bool DesignerExists(int id)
        {
            return _context.Designer.Any(e => e.DesignerID == id);
        }
    }
}
