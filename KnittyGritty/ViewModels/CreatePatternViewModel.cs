namespace KnittyGritty.ViewModels
{
    public class CreatePatternViewModel
    {
        // Grundinfo
        public int DesignerID { get; set; }
        public string Title { get; set; } = "";
        public float Gauge { get; set; }
        public float Needles { get; set; }
        public string? Notes { get; set; }
        public string? PatternType { get; set; }
        public string? Source { get; set; }
        public string Craft { get; set; } = "";
        public bool MultipleStrands { get; set; } = false;
        public string? OverallYarnWeight { get; set; }
        public string? GaugePattern { get; set; }

        // Kategorier, språk och garn (enkla val)
        public List<int> SelectedCategoryIDs { get; set; } = new List<int>();
        public List<int> SelectedLanguageIDs { get; set; } = new List<int>();

        // Garn med eventuell färg
        public List<PatternYarnInput> SelectedYarns { get; set; } = new List<PatternYarnInput>();

        // Storlekar med extra data
        public List<PatternSizeInput> Sizes { get; set; } = new List<PatternSizeInput>();

    }

    public class PatternYarnInput
    {
        public int YarnID { get; set; }
        public string? Color { get; set; }
    }

    public class PatternSizeInput
    {
        public int SizeID { get; set; }
        public int Circumference { get; set; }
        public string? Notes { get; set; }
    }

}
