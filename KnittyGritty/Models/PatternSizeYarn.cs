using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class PatternSizeYarn
    {
        public int PatternSizeYarnID { get; set; } // PK

        [Display(Name = "Mönster")]
        public int PatternID { get; set; } // FK

        [Display(Name = "Mönster")]
        public Pattern Pattern { get; set; } = null!;

        [Display(Name = "Storlek")]
        public int SizeID { get; set; } // FK

        [Display(Name = "Storlek")]
        public Size Size { get; set; } = null!;

        [Display(Name = "Garn")]
        public int YarnID { get; set; } // FK

        [Display(Name = "Garn")]
        public Yarn Yarn { get; set; } = null!;

        [Display(Name = "Åtgång i nystan")]
        public float SkeinUsage { get; set; }

        [Display(Name = "Åtgång i meter")]
        public int MeterageUsage { get; set; }

        [Display(Name = "Färg")]
        public string? Color { get; set; }
    }
}
