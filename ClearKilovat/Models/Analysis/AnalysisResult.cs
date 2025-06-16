namespace ClearKilovat.Models.Analysis
{
    public class AnalysisResult
    {
        public int AccountId { get; set; }
        public string DescriptionReason { get; set; } = string.Empty;
        public bool IsCommercial { get; set; }
        public DateTime PredictedAt { get; set; }
    }
}
