using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KnittyGritty.Pages.Sizes
{
    public class CreateModalModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public CreateModalModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        [BindProperty] public string SizeName { get; set; } = "";

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(SizeName))
                return BadRequest("Namn krävs");

            var size = new Size
            {
                SizeName = SizeName
            };

            _context.Size.Add(size);
            await _context.SaveChangesAsync();

            return new JsonResult(new
            {
                id = size.SizeID,
                name = size.SizeName
            });
        }
    }
}
