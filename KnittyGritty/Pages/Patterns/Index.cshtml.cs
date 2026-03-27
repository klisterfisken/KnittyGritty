using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Patterns
{
    public class IndexModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public IndexModel(KnittyGritty.Data.KnittyGrittyContext context)
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
