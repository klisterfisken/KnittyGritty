using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.YarnBrands
{
    public class IndexModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public IndexModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        public IList<YarnBrand> YarnBrand { get;set; } = default!;

        public async Task OnGetAsync()
        {
            YarnBrand = await _context.YarnBrand.ToListAsync();
        }
    }
}
