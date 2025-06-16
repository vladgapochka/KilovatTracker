using ClearKilovat.Models.Entity;
using ClearKilovat.Models.Parser;

namespace ClearKilovat.Interfaces
{
    public interface ICompanySearchService
    {
        Task<IdPurposeDTO> GetBuildingId(string address);
        Task<List<Company>> GetCompaniesInBuilding(string buildingId);
        bool IsCommercialBuilding(string purposeName);
    }
}
