using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.YarnBrands
{
    public class DeleteModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public DeleteModel(KnittyGrittyContext context)
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

            var yarnbrand = await _context.YarnBrand.FirstOrDefaultAsync(m => m.YarnBrandID == id);

            if (yarnbrand is not null)
            {
                YarnBrand = yarnbrand;

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

            var yarnbrand = await _context.YarnBrand.FindAsync(id);
            if (yarnbrand != null)
            {
                YarnBrand = yarnbrand;
                _context.YarnBrand.Remove(YarnBrand);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
