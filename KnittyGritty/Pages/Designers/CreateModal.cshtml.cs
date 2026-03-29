using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KnittyGritty.Pages.Designers
{
    public class CreateModalModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public CreateModalModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        [BindProperty] public string DesignerName { get; set; } = "";
        [BindProperty] public string? Alias { get; set; }
        [BindProperty] public string? Website { get; set; }
        [BindProperty] public string? Handle { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(DesignerName))
                return BadRequest("Namn krävs");

            var designer = new Designer
            {
                Name = DesignerName,
                Alias = Alias,
                Website = Website,
                Handle = Handle
            };

            _context.Designer.Add(designer);
            await _context.SaveChangesAsync();

            return new JsonResult(new
            {
                id = designer.DesignerID,
                name = designer.Name,
            });
        }
    }
}
