using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Patterns
{
    public class DetailsModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public DetailsModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        public Pattern Pattern { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pattern = await _context.Pattern
                .Include(p => p.Designer)
                .Include(p => p.PatternCategories).ThenInclude(pc => pc.Category)
                .Include(p => p.PatternLanguages).ThenInclude(pl => pl.Language)
                .Include(p => p.PatternYarns).ThenInclude(py => py.Yarn).ThenInclude(y => y.YarnBrand)
                .Include(p => p.PatternSizes).ThenInclude(ps => ps.Size)
                .Include(p => p.PatternSizeYarns).ThenInclude(psy => psy.Yarn).ThenInclude(y => y.YarnBrand)
                .Include(p => p.PatternSizeYarns).ThenInclude(psy => psy.Size)
                .AsSplitQuery()
                .FirstOrDefaultAsync(m => m.PatternID == id);

            if (pattern is null) return NotFound();

            Pattern = pattern;
            return Page();
        }
    }
}
