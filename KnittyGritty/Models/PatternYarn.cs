using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class PatternYarn
    {
        public int PatternYarnID { get; set; } // PK (surrogate)

        [Display(Name = "Mönster")]
        public int PatternID { get; set; } // FK

        [Display(Name = "Mönster")]
        public Pattern Pattern { get; set; } = null!;

        [Display(Name = "Garn")]
        public int YarnID { get; set; } // FK

        [Display(Name = "Garn")]
        public Yarn Yarn { get; set; } = null!;

        [Display(Name = "Färg")]
        public string? Color { get; set; }
    }
}
