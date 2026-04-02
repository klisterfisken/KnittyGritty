using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnittyGritty.Pages
{
    public class IndexModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public IndexModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        public List<Pattern> RecentPatterns { get; set; } = new();

        public async Task OnGetAsync()
        {
            RecentPatterns = await _context.Pattern
                .Include(p => p.Designer)
                .OrderByDescending(p => p.PatternID)
                .Take(4)
                .ToListAsync();
        }
    }
}
