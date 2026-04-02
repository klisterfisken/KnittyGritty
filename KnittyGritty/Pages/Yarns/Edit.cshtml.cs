using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KnittyGritty.Pages.Yarns
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
        public Yarn Yarn { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yarn =  await _context.Yarn.FirstOrDefaultAsync(m => m.YarnID == id);
            if (yarn == null)
            {
                return NotFound();
            }
            Yarn = yarn;
           ViewData["YarnBrandID"] = new SelectList(_context.YarnBrand, "YarnBrandID", "YarnBrandID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Yarn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnExists(Yarn.YarnID))
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

        private bool YarnExists(int id)
        {
            return _context.Yarn.Any(e => e.YarnID == id);
        }
    }
}
