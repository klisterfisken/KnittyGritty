using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class PatternLanguage
    {
        [Display(Name = "Mönster")]
        public int PatternID { get; set; } // FK

        [Display(Name = "Mönster")]
        public Pattern Pattern { get; set; } = null!;

        [Display(Name = "Språk")]
        public int LanguageID { get; set; } // FK

        [Display(Name = "Språk")]
        public Language Language { get; set; } = null!;
    }
}
