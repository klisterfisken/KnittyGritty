using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Data;
using KnittyGritty.Models;

namespace KnittyGritty.Pages.Designers
{
    public class IndexModel : PageModel
    {
        private readonly KnittyGritty.Data.KnittyGrittyContext _context;

        public IndexModel(KnittyGritty.Data.KnittyGrittyContext context)
        {
            _context = context;
        }

        public IList<Designer> Designer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Designer = await _context.Designer.ToListAsync();
        }
    }
}
