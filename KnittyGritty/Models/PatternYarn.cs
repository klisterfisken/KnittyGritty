namespace KnittyGritty.Models
{
    public class PatternYarn
    {
        public int PatternID { get; set; } // FK
        public Pattern Pattern { get; set; } = null!;

        public int YarnID { get; set; } // FK
        public Yarn Yarn { get; set; } = null!;
    }
}
