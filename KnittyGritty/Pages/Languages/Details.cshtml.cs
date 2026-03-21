using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Languages
{
    public class DetailsModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public DetailsModel(KnittyGritty.Data.KnittyGrittyContext context)
        {
            _context = context;
        }

        public Language Language { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language.FirstOrDefaultAsync(m => m.LanguageID == id);

            if (language is not null)
            {
                Language = language;

                return Page();
            }

            return NotFound();
        }
    }
}
