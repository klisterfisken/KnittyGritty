using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Sizes
{
    public class DetailsModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public DetailsModel(KnittyGritty.Data.KnittyGrittyContext context)
        {
            _context = context;
        }

        public Size Size { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size = await _context.Size.FirstOrDefaultAsync(m => m.SizeID == id);

            if (size is not null)
            {
                Size = size;

                return Page();
            }

            return NotFound();
        }
    }
}
