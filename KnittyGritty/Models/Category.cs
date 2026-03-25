using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class Category
    {
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; } // PK

        [Display(Name = "Kategori")]
        public string CategoryName { get; set; } = "";

        // Navigation collection
        public ICollection<PatternCategory> PatternCategories { get; set; } = new List<PatternCategory>();
    }
}
