using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Languages
{
    public class IndexModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public IndexModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        public IList<Language> Language { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Language = await _context.Language.ToListAsync();
        }
    }
}
