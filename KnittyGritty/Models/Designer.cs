namespace KnittyGritty.Models
{
    public class Designer
    {
        public int DesignerID { get; set; } // PK
        public string Name { get; set; } = "";
        public string? Alias { get; set; }
        public string? Website { get; set; }
        public string? Handle { get; set; }
    }
}
