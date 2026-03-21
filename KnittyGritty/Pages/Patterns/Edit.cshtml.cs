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

namespace KnittyGritty.Pages.Patterns
{
    public class EditModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public EditModel(KnittyGritty.Data.KnittyGrittyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pattern Pattern { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pattern =  await _context.Pattern.FirstOrDefaultAsync(m => m.PatternID == id);
            if (pattern == null)
            {
                return NotFound();
            }
            Pattern = pattern;
           ViewData["DesignerID"] = new SelectList(_context.Designer, "DesignerID", "DesignerID");
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

            _context.Attach(Pattern).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatternExists(Pattern.PatternID))
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

        private bool PatternExists(int id)
        {
            return _context.Pattern.Any(e => e.PatternID == id);
        }
    }
}
