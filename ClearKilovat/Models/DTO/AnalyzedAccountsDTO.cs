using ClearKilovat.Models.Entity;

namespace ClearKilovat.Models.DTO
{
    public class AnalyzedAccountsDTO
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string? Address { get; set; }

        public string? SuggestionByMaps { get; set; }

        public string? SuggestionByNeuralModels { get; set; }

        public double? DecisionConfidencePercent { get; set; }
    }
}
