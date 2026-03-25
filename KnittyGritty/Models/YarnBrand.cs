using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class YarnBrand
    {
        [Display(Name = "Märke")]
        public int YarnBrandID { get; set; } //PK

        [Display(Name = "Märke")]
        public string YarnBrandName { get; set; } = "";
    }
}
