using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class Size
    {
        [Display(Name = "Storlek")]
        public int SizeID { get; set; } // PK

        [Display(Name = "Storlek")]
        public string SizeName { get; set; } = "";

        [Display(Name = "Sorteringsnummer")]
        public decimal SortOrder { get; set; }

        // Navigation collections
        public ICollection<PatternSize> PatternSizes { get; set; } = new List<PatternSize>();
        public ICollection<PatternSizeYarn> PatternSizeYarns { get; set; } = new List<PatternSizeYarn>();
    }
}
