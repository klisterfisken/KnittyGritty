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

namespace KnittyGritty.Pages.Sizes
{
    public class EditModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public EditModel(KnittyGritty.Data.KnittyGrittyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Size Size { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size =  await _context.Size.FirstOrDefaultAsync(m => m.SizeID == id);
            if (size == null)
            {
                return NotFound();
            }
            Size = size;
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

            _context.Attach(Size).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeExists(Size.SizeID))
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

        private bool SizeExists(int id)
        {
            return _context.Size.Any(e => e.SizeID == id);
        }
    }
}
