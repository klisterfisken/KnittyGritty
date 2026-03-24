using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class PatternLanguage
    {
        public int PatternID { get; set; } // FK

        [Display(Name = "Mönster")]
        public Pattern Pattern { get; set; } = null!;

        public int LanguageID { get; set; } // FK

        [Display(Name = "Språk")]
        public Language Language { get; set; } = null!;
    }
}
