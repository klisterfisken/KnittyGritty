using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Yarns
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
