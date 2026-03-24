using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class Yarn
    {
        public int YarnID { get; set; } // PK

        [Display(Name ="Märke")]
        public int YarnBrandID { get; set; } // FK
        [Display(Name ="Märke")]
        public YarnBrand? YarnBrand { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; } = "";

        [Display(Name = "Grovlek")]
        public string YarnWeight { get; set; } = "";

        [Display(Name = "Vikt")]
        public int UnitWeight { get; set; }

        [Display(Name = "Löplängd")]
        public int Meterage { get; set; }

        [Display(Name = "Innehåll")]
        public string? FiberContent { get; set; }

        // Navigation collections
        public ICollection<PatternYarn> PatternYarns { get; set; } = new List<PatternYarn>();
        public ICollection<PatternSizeYarn> PatternSizeYarns { get; set; } = new List<PatternSizeYarn>();

    }
}
