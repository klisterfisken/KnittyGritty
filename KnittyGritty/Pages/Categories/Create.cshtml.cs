using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Categories
{
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
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
