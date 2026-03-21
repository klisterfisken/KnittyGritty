namespace KnittyGritty.Models
{
    public class Size
    {
        public int SizeID { get; set; } // PK
        public string SizeName { get; set; } = "";
        public decimal SortOrder { get; set; }

        // Navigation collections
        public ICollection<PatternSize> PatternSizes { get; set; } = new List<PatternSize>();
        public ICollection<PatternSizeYarn> PatternSizeYarns { get; set; } = new List<PatternSizeYarn>();
    }
}
