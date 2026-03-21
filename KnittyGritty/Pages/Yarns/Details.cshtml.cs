using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Yarns
{
    public class DetailsModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public DetailsModel(KnittyGritty.Data.KnittyGrittyContext context)
        {
            _context = context;
        }

        public Yarn Yarn { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yarn = await _context.Yarn.FirstOrDefaultAsync(m => m.YarnID == id);

            if (yarn is not null)
            {
                Yarn = yarn;

                return Page();
            }

            return NotFound();
        }
    }
}
