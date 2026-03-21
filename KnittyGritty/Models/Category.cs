namespace KnittyGritty.Models
{
    public class Category
    {
        public int CategoryID { get; set; } // PK
        public string CategoryName { get; set; } = "";

        // Navigation collection
        public ICollection<PatternCategory> PatternCategories { get; set; } = new List<PatternCategory>();
    }
}
