using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.YarnBrands
{
    public class EditModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public EditModel(KnittyGritty.Data.KnittyGrittyContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
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
