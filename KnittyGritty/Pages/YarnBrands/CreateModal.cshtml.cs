using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.YarnBrands
{
    public class CreateModalModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public CreateModalModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string YarnBrandName { get; set; } = "";

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(YarnBrandName))
            {
                return BadRequest("Namn krävs.");
            }

            var brand = new YarnBrand
            {
                YarnBrandName = YarnBrandName
            };
            _context.YarnBrand.Add(brand);
            await _context.SaveChangesAsync();

            return new JsonResult(new { id = brand.YarnBrandID, name = brand.YarnBrandName });
        }
    }
}
