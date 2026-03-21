namespace KnittyGritty.Models
{
    public class PatternCategory
    {
        public int PatternID { get; set; } // FK
        public Pattern Pattern { get; set; } = null!;

        public int CategoryID { get; set; } // FK
        public Category Category { get; set; } = null!;
    }
}
