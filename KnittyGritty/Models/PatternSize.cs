using System.Drawing;

namespace KnittyGritty.Models
{
    public class PatternSize
    {
        public int PatternID { get; set; } // FK
        public Pattern Pattern { get; set; } = null!;

        public int SizeID { get; set; } // FK
        public Size Size { get; set; } = null!;

        public int Circumference { get; set; }
        public string? Notes { get; set; }
    }
}
