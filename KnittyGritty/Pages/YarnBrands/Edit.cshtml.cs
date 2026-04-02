using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnittyGritty.Pages.YarnBrands
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
        public YarnBrand YarnBrand { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yarnbrand =  await _context.YarnBrand.FirstOrDefaultAsync(m => m.YarnBrandID == id);
            if (yarnbrand == null)
            {
                return NotFound();
            }
            YarnBrand = yarnbrand;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(YarnBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnBrandExists(YarnBrand.YarnBrandID))
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

        private bool YarnBrandExists(int id)
        {
            return _context.YarnBrand.Any(e => e.YarnBrandID == id);
        }
    }
}
