using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Designers
{
    public class DetailsModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public DetailsModel(KnittyGritty.Data.KnittyGrittyContext context)
        {
            _context = context;
        }

        public Designer Designer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designer = await _context.Designer.FirstOrDefaultAsync(m => m.DesignerID == id);

            if (designer is not null)
            {
                Designer = designer;

                return Page();
            }

            return NotFound();
        }
    }
}
