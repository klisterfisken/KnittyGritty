using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Patterns
{
    public class CreateModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public CreateModel(KnittyGritty.Data.KnittyGrittyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DesignerID"] = new SelectList(_context.Designer, "DesignerID", "DesignerID");
            return Page();
        }

        [BindProperty]
        public Pattern Pattern { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pattern.Add(Pattern);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
