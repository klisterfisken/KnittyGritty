using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace KnittyGritty.Models
{
    public class PatternSize
    {
        [Display(Name = "Mönster")]
        public int PatternID { get; set; } // FK

        [Display(Name = "Mönster")]
        public Pattern Pattern { get; set; } = null!;

        [Display(Name = "Storlek")]
        public int SizeID { get; set; } // FK

        [Display(Name = "Storlek")]
        public Size Size { get; set; } = null!;

        [Display(Name = "Omkrets")]
        public int Circumference { get; set; }

        [Display(Name = "Anteckningar")]
        public string? Notes { get; set; }
    }
}
