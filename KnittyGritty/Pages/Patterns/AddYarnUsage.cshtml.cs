using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnittyGritty.Pages.Patterns
{
    [Authorize]
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
        public List<ExistingEntryDto> ExistingEntries { get; set; } = new();


        [BindProperty]
        public List<PatternSizeYarnInput> SizeYarns { get; set; } = new List<PatternSizeYarnInput>();

        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }


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

            var existingSizeYarns = await _context.PatternSizeYarn
                .Where(psy => psy.PatternID == id)
                .ToListAsync();

            ExistingEntries = existingSizeYarns.Select(psy => new ExistingEntryDto
            {
                SizeID = psy.SizeID,
                PatternYarnID = PatternYarns
                    .FirstOrDefault(py => py.YarnID == psy.YarnID && py.Color == psy.Color)
                    ?.PatternYarnID ?? 0,
                GramUsage = psy.GramUsage,
                MeterageUsage = psy.MeterageUsage
            }).ToList();


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var patternYarns = await _context.PatternYarn
                .Where(py => py.PatternID == id)
                .ToListAsync();

            var existing = await _context.PatternSizeYarn
                .Where(psy => psy.PatternID == id)
                .ToListAsync();
            _context.PatternSizeYarn.RemoveRange(existing);

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
                    GramUsage = entry.GramUsage,
                    MeterageUsage = entry.MeterageUsage
                });
            }

            await _context.SaveChangesAsync();
            if (!string.IsNullOrEmpty(ReturnUrl))
                return Redirect(ReturnUrl);
            return RedirectToPage("./Index");

        }

    }

    public class PatternSizeYarnInput
    {
        public int SizeID { get; set; }
        public int PatternYarnID { get; set; }
        public int GramUsage { get; set; }
        public int MeterageUsage { get; set; }
    }

    public class ExistingEntryDto
    {
        public int SizeID { get; set; }
        public int PatternYarnID { get; set; }
        public int GramUsage { get; set; }
        public int MeterageUsage { get; set; }
    }
}
