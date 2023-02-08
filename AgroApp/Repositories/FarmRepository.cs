using AgroApp.Data;
using AgroApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgroApp.Repositories
{
    public class FarmRepository : IFarmRepository
    {

        private readonly ApplicationDbContext _context;

        public FarmRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddFarm(FarmModel farm)
        {
            _context.Farms.Add(farm);
            _context.SaveChanges();
        }

        public void DeleteFarm(int farmId)
        {
            var result = _context.Farms.SingleOrDefault(x => x.FarmId == farmId);
            if(result != null)
            {
                _context.Farms.Remove(result);
            }
            
            _context.SaveChanges();
        }

        public FarmModel GetFarmById(int? farmId)
            => _context.Farms.SingleOrDefault(x => x.FarmId == farmId);

        public FarmModel GetFarmByName(string name)
            => _context.Farms.SingleOrDefault(x => x.FarmName == name);

        public FarmModel GetFarmByUserId(string id)
            => _context.Farms.SingleOrDefault(x => x.FarmOwnerId == id);

        public IEnumerable<FarmModel> GetFarms()
            => _context.Farms.ToList();

        public void UpdateFarm(int farmId, FarmModel farm)
        {
            var result = _context.Farms.SingleOrDefault(x => x.FarmId == farmId);
            if(result != null)
            {
                result.FarmName = farm.FarmName;
                result.FarmOwnerName = farm.FarmOwnerName;
                result.FarmStatus = farm.FarmStatus;
                result.FarmOwnerId = farm.FarmOwnerId;

                _context.SaveChanges();
            }
        }
         
    }
}
