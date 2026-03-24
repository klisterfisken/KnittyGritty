using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class Language
    {
        public int LanguageID { get; set; } // PK

        [Display(Name = "Språk")]
        public string LanguageName { get; set; } = "";

        // Navigation collection
        public ICollection<PatternLanguage> PatternLanguages { get; set; } = new List<PatternLanguage>();

    }
}
