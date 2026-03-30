
using KnittyGritty.Data;
using KnittyGritty.Models;
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

        public async Task OnGetAsync()
        {
            Pattern = await _context.Pattern
                .Include(p => p.Designer)
                .Include(p => p.PatternCategories)
                    .ThenInclude(pc => pc.Category)
                .ToListAsync();
        }
    }
}
