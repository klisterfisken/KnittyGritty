using System.ComponentModel.DataAnnotations;

namespace KnittyGritty.Models
{
    public class Designer
    {
        public int DesignerID { get; set; } // PK

        [Display(Name = "Namn")]
        public string Name { get; set; } = "";

        [Display(Name = "Smeknamn")]
        public string? Alias { get; set; }

        [Display(Name = "Hemsida")]
        public string? Website { get; set; }

        [Display(Name = "Instagram")]
        public string? Handle { get; set; }
    }
}
