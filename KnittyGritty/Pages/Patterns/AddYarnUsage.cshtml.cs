using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnittyGritty.Pages.Patterns
{
    public class AddYarnUsageModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public AddYarnUsageModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        public Pattern Pattern { get; set; } = default!;
        public List<PatternSize> PatternSizes { get; set; } = new List<PatternSize>();
        public List<PatternYarn> PatternYarns { get; set; } = new List<PatternYarn>();

        [BindProperty]
        public List<PatternSizeYarnInput> SizeYarns { get; set; } = new List<PatternSizeYarnInput>();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var pattern = await _context.Pattern.FindAsync(id);
            if (pattern == null) return NotFound();

            Pattern = pattern;

            PatternSizes = await _context.PatternSize
                .Where(ps => ps.PatternID == id)
                .Include(ps => ps.Size)
                .OrderBy(ps => ps.Size.SortOrder)
                .ToListAsync();

            PatternYarns = await _context.PatternYarn
                .Where(py => py.PatternID == id)
                .Include(py => py.Yarn).ThenInclude(y => y.YarnBrand)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var patternYarns = await _context.PatternYarn
                .Where(py => py.PatternID == id)
                .ToListAsync();

            foreach (var entry in SizeYarns)
            {
                var patternYarn = patternYarns.FirstOrDefault(py => py.PatternYarnID == entry.PatternYarnID);
                if (patternYarn == null) continue;

                _context.PatternSizeYarn.Add(new PatternSizeYarn
                {
                    PatternID = id,
                    SizeID = entry.SizeID,
                    YarnID = patternYarn.YarnID,
                    Color = patternYarn.Color,
                    SkeinUsage = entry.SkeinUsage,
                    MeterageUsage = entry.MeterageUsage
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }

    public class PatternSizeYarnInput
    {
        public int SizeID { get; set; }
        public int PatternYarnID { get; set; }
        public float SkeinUsage { get; set; }
        public int MeterageUsage { get; set; }
    }
}
