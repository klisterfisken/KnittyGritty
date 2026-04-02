using KnittyGritty.Data;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KnittyGritty.Pages.Yarns
{
    public class CreateModalModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public CreateModalModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        [BindProperty] public int? YarnBrandID { get; set; }
        [BindProperty] public string? NewYarnBrandName { get; set; }
        [BindProperty] public string YarnName { get; set; } = "";
        [BindProperty] public string YarnWeight { get; set; } = "";
        [BindProperty] public int UnitWeight { get; set; }
        [BindProperty] public int Meterage { get; set; }
        [BindProperty] public string? FiberContent { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(YarnName))            {
                return BadRequest("Namn krävs");
            }

            if (!string.IsNullOrWhiteSpace(NewYarnBrandName))
            {
                var brand = new YarnBrand { YarnBrandName = NewYarnBrandName };
                _context.YarnBrand.Add(brand);
                await _context.SaveChangesAsync();
                YarnBrandID = brand.YarnBrandID;
            }

            if (YarnBrandID == null)
            {
                return BadRequest("Garnmärke krävs");
            }

            var yarn = new Yarn
            {
                YarnBrandID = YarnBrandID.Value,
                Name = YarnName,
                YarnWeight = YarnWeight,
                UnitWeight = UnitWeight,
                Meterage = Meterage,
                FiberContent = FiberContent
            };

            _context.Yarn.Add(yarn);
            await _context.SaveChangesAsync();

            var brandName = NewYarnBrandName ?? _context.YarnBrand.Find(YarnBrandID)?.YarnBrandName;

            return new JsonResult(new
            {
                id = yarn.YarnID,
                name = brandName + " " + yarn.Name,
                brandId = yarn.YarnBrandID
            });
        }
    }
}
