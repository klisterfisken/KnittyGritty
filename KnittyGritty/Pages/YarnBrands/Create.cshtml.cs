using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KnittyGritty.Pages.YarnBrands
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public CreateModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public YarnBrand YarnBrand { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.YarnBrand.Add(YarnBrand);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
