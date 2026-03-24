using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace KnittyGritty.Models
{
    public class PatternSizeYarn
    {
        public int PatternID { get; set; } // FK

        [Display(Name = "Mönster")]
        public Pattern Pattern { get; set; } = null!;

        public int SizeID { get; set; } // FK

        [Display(Name = "Storlek")]
        public Size Size { get; set; } = null!;

        public int YarnID { get; set; } // FK

        [Display(Name = "Garn")]
        public Yarn Yarn { get; set; } = null!;

        [Display(Name = "Åtgång i nystan")]
        public float SkeinUsage { get; set; }

        [Display(Name = "Åtgång i meter")]
        public int MeterageUsage { get; set; }
    }
}
