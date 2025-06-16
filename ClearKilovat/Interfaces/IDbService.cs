using ClearKilovat.Models.Entity;

namespace ClearKilovat.Interfaces
{
    public interface IDbService
    {
        public Task ImportFromFileAsync();
        public List<Account> GetAccounts();
        public List<Company> GetCompanies();
        public Task InsertCompanies(List<Company> companies);   
        public Task InsertFeedback(Feedback newFeedback);   
        public Task<List<Account>> GetAccountErrors();
        public List<ParserAnalytics> GetParserAnalytics();
        public Task AddAnalyticToDb(ParserAnalytics parsedAnalytic);
        public List<Feedback> GetFeedbacks();
    }
}
