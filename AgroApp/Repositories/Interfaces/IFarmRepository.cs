using AgroApp.Models;

namespace AgroApp.Repositories
{
    public interface IFarmRepository
    {
        FarmModel GetFarmById(int? farmId);
        FarmModel GetFarmByName(string name);
        FarmModel GetFarmByUserId(string id);
        IEnumerable<FarmModel> GetFarms();
        void AddFarm(FarmModel farm);
        void UpdateFarm(int farmId, FarmModel farm);
        void DeleteFarm(int farmId);
    }
}
