using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class PatternYarn
    {
        public int PatternID { get; set; } // FK

        [Display(Name = "Mönster")]
        public Pattern Pattern { get; set; } = null!;

        public int YarnID { get; set; } // FK

        [Display(Name = "Garn")]
        public Yarn Yarn { get; set; } = null!;
    }
}
