using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KnittyGritty.Pages.Yarns
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
            ViewData["YarnBrandID"] = new SelectList(
                _context.YarnBrand.OrderBy(y => y.YarnBrandName),
                "YarnBrandID",
                "YarnBrandName");
            return Page();
        }

        [BindProperty]
        public Yarn Yarn { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["YarnBrandID"] = new SelectList(
                    _context.YarnBrand.OrderBy(y => y.YarnBrandName),
                    "YarnBrandID",
                    "YarnBrandName");
                return Page();
            }

            _context.Yarn.Add(Yarn);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
