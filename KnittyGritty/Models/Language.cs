namespace KnittyGritty.Models
{
    public class Language
    {
        public int LanguageID { get; set; } // PK
        public string LanguageName { get; set; } = "";

        // Navigation collection
        public ICollection<PatternLanguage> PatternLanguages { get; set; } = new List<PatternLanguage>();

    }
}
