using System.Drawing;

namespace KnittyGritty.Models
{
    public class PatternSizeYarn
    {
        public int PatternID { get; set; } // FK
        public Pattern Pattern { get; set; } = null!;

        public int SizeID { get; set; } // FK
        public Size Size { get; set; } = null!;

        public int YarnID { get; set; } // FK
        public Yarn Yarn { get; set; } = null!;

        public float SkeinUsage { get; set; }
        public int MeterageUsage { get; set; }
    }
}
