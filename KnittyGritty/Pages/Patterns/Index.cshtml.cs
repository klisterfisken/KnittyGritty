
using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnittyGritty.Pages.Patterns
{
    public class IndexModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public IndexModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        public IList<Pattern> Pattern { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 12;

        public int TotalPages { get; set; }

        public async Task OnGetAsync()
        {
            var validSizes = new[] { 12, 24, 48 };
            if (!validSizes.Contains(PageSize)) PageSize = 12;

            var query = _context.Pattern
                .Include(p => p.Designer)
                .Include(p => p.PatternCategories)
                    .ThenInclude(pc => pc.Category)
                .AsNoTracking();

            var total = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(total / (double)PageSize);
            if (PageIndex < 1) PageIndex = 1;
            if (PageIndex > TotalPages && TotalPages > 0) PageIndex = TotalPages;

            Pattern = await query
                .OrderBy(p => p.Title)
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
