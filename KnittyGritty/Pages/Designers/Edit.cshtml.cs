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

namespace KnittyGritty.Pages.Designers
{
    public class EditModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public EditModel(KnittyGritty.Data.KnittyGrittyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Designer Designer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designer =  await _context.Designer.FirstOrDefaultAsync(m => m.DesignerID == id);
            if (designer == null)
            {
                return NotFound();
            }
            Designer = designer;
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

            _context.Attach(Designer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignerExists(Designer.DesignerID))
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

        private bool DesignerExists(int id)
        {
            return _context.Designer.Any(e => e.DesignerID == id);
        }
    }
}
