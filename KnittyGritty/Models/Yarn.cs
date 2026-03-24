namespace KnittyGritty.Models
{
    public class Yarn
    {
        public int YarnID { get; set; } // PK

        public int YarnBrandID { get; set; } // FK
        public YarnBrand? YarnBrand { get; set; }

        public string Name { get; set; } = "";
        public string YarnWeight { get; set; } = "";
        public int UnitWeight { get; set; }
        public int Meterage { get; set; }
        public string? FiberContent { get; set; }

        // Navigation collections
        public ICollection<PatternYarn> PatternYarns { get; set; } = new List<PatternYarn>();
        public ICollection<PatternSizeYarn> PatternSizeYarns { get; set; } = new List<PatternSizeYarn>();

    }
}
