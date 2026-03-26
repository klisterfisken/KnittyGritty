using KnittyGritty.Data;
using KnittyGritty.Models;
using KnittyGritty.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnittyGritty.Pages.Patterns
{
    public class CreateModel : PageModel
    {
        private readonly KnittyGrittyContext _context;

        public CreateModel(KnittyGrittyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreatePatternViewModel Input { get; set; } = new CreatePatternViewModel();

        // Listor för dropdowns/checkboxar
        public SelectList DesignerList { get; set; } = default!;
        public SelectList CategoryList { get; set; } = default!;
        public SelectList LanguageList { get; set; } = default!;
        public SelectList YarnList { get; set; } = default!;
        public SelectList SizeList { get; set; } = default!;

        public IActionResult OnGet()
        {
            PopulateLists();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateLists();
                return Page();
            }

            // Skapa Pattern
            var pattern = new Pattern
            {
                DesignerID = Input.DesignerID,
                Title = Input.Title,
                Gauge = Input.Gauge,
                Needles = Input.Needles,
                Difficulty = Input.Difficulty,
                Notes = Input.Notes,
                ImageUrl = Input.ImageUrl,
                PatternType = Input.PatternType,
                Source = Input.Source,
                Craft = Input.Craft,
                MultipleStrands = Input.MultipleStrands,
                OverallYarnWeight = Input.OverallYarnWeight,
                GaugePattern = Input.GaugePattern
            };

            _context.Pattern.Add(pattern);
            await _context.SaveChangesAsync();

            // Kategorier
            foreach (var categoryId in Input.SelectedCategoryIDs)
            {
                _context.PatternCategory.Add(new PatternCategory
                {
                    PatternID = pattern.PatternID,
                    CategoryID = categoryId
                });
            }

            // Språk
            foreach (var languageId in Input.SelectedLanguageIDs)
            {
                _context.PatternLanguage.Add(new PatternLanguage
                {
                    PatternID = pattern.PatternID,
                    LanguageID = languageId
                });
            }

            // Garn
            foreach (var yarn in Input.SelectedYarns)
            {
                _context.PatternYarn.Add(new PatternYarn
                {
                    PatternID = pattern.PatternID,
                    YarnID = yarn.YarnID,
                    Color = yarn.Color
                });
            }

            // Storlekar
            foreach (var size in Input.Sizes)
            {
                _context.PatternSize.Add(new PatternSize
                {
                    PatternID = pattern.PatternID,
                    SizeID = size.SizeID,
                    Circumference = size.Circumference,
                    Notes = size.Notes
                });
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./AddYarnUsage", new { id = pattern.PatternID });
        }

        private void PopulateLists()
        {
            DesignerList = new SelectList(
                _context.Designer.OrderBy(d => d.Name),
                "DesignerID",
                "Name");

            CategoryList = new SelectList(
                _context.Category.OrderBy(c => c.CategoryName),
                "CategoryID",
                "CategoryName");

            LanguageList = new SelectList(
                _context.Language.OrderBy(l => l.LanguageName),
                "LanguageID",
                "LanguageName");

            var yarns = _context.Yarn
                .Include(y => y.YarnBrand)
                .OrderBy(y => y.YarnBrand.YarnBrandName)
                .ThenBy(y => y.Name)
                .Select(y => new {
                    y.YarnID,
                    DisplayName = y.YarnBrand.YarnBrandName + " – " + y.Name
                })
                .ToList();
            YarnList = new SelectList(yarns, "YarnID", "DisplayName");

            SizeList = new SelectList(
                _context.Size.OrderBy(s => s.SortOrder),
                "SizeID",
                "SizeName");

        }
    }
}
