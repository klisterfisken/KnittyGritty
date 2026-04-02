using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Yarns
{
    public class IndexModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public IndexModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        public IList<Yarn> Yarn { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Yarn = await _context.Yarn
                .Include(y => y.YarnBrand).ToListAsync();
        }
    }
}
