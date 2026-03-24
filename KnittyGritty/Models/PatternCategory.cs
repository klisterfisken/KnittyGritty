using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class PatternCategory
    {
        public int PatternID { get; set; } // FK

        [Display(Name = "Mönster")]
        public Pattern Pattern { get; set; } = null!;

        public int CategoryID { get; set; } // FK

        [Display(Name = "Kategori")]
        public Category Category { get; set; } = null!;
    }
}
