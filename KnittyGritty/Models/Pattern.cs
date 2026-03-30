using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class Pattern
    {
        public int PatternID { get; set; } // PK

        [Display(Name = "Designer")]
        public int DesignerID { get; set; } // FK
        public Designer? Designer { get; set; }

        [Display(Name = "Namn")]
        public string Title { get; set; } = "";

        [Display(Name = "Masktäthet")]
        public float Gauge { get; set; }

        [Display(Name = "Stickor / Virknål")]
        public float Needles { get; set; }

        [Display(Name = "Anteckningar")]
        public string? Notes { get; set; }

        [Display(Name = "Mönstertyp")]
        public string? PatternType { get; set; }

        [Display(Name = "Källa")]
        public string? Source { get; set; }

        [Display(Name = "Teknik")]
        public string Craft { get; set; } = "";

        [Display(Name = "Flera trådar?")]
        public bool MultipleStrands { get; set; } = false;

        [Display(Name = "Sammanlagd grovlek")]
        public string? OverallYarnWeight { get; set; }

        [Display(Name = "Mönster för masktäthet")]
        public string? GaugePattern { get; set; }

        // Navigation collections
        public ICollection<PatternCategory> PatternCategories { get; set; } = new List<PatternCategory>();
        public ICollection<PatternLanguage> PatternLanguages { get; set; } = new List<PatternLanguage>();
        public ICollection<PatternYarn> PatternYarns { get; set; } = new List<PatternYarn>();
        public ICollection<PatternSize> PatternSizes { get; set; } = new List<PatternSize>();
        public ICollection<PatternSizeYarn> PatternSizeYarns { get; set; } = new List<PatternSizeYarn>();

    }
}
