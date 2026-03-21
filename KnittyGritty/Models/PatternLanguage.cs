namespace KnittyGritty.Models
{
    public class PatternLanguage
    {
        public int PatternID { get; set; } // FK
        public Pattern Pattern { get; set; } = null!;

        public int LanguageID { get; set; } // FK
        public Language Language { get; set; } = null!;
    }
}
