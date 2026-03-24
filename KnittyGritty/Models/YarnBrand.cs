using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class YarnBrand
    {
        public int YarnBrandID { get; set; } //PK

        [Display(Name = "Märke")]
        public string YarnBrandName { get; set; } = "";
    }
}
