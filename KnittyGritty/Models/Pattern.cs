namespace KnittyGritty.Models
{
    public class Pattern
    {
        public int PatternID { get; set; } // PK

        public int DesignerID { get; set; } // FK
        public Designer Designer { get; set; } = null!;

        public string Title { get; set; } = "";
        public float Gauge { get; set; }
        public float Needles { get; set; }
        public string? Difficulty { get; set; }
        public string? Notes { get; set; }
        public string? ImageUrl { get; set; }
        public string? PatternType { get; set; }
        public string? Source { get; set; }
        public string Craft { get; set; } = "";
        public bool MultipleStrands { get; set; } = false;
        public string? OverallYarnWeight { get; set; }
        public string? GaugePattern { get; set; }

        // Navigation collections
        public ICollection<PatternCategory> PatternCategories { get; set; } = new List<PatternCategory>();
        public ICollection<PatternLanguage> PatternLanguages { get; set; } = new List<PatternLanguage>();
        public ICollection<PatternYarn> PatternYarns { get; set; } = new List<PatternYarn>();
        public ICollection<PatternSize> PatternSizes { get; set; } = new List<PatternSize>();
        public ICollection<PatternSizeYarn> PatternSizeYarns { get; set; } = new List<PatternSizeYarn>();

    }
}
