using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.YarnBrands
{
    public class DetailsModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public DetailsModel(KnittyGrittyContext context)
        {
            _context = context;
        }

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
    }
}
