using AgroApp.Data;
using AgroApp.Models;
using AgroApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgroApp.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly ApplicationDbContext _context;

        public MachineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMachine(MachineModel machine)
        {
            _context.Machines.Add(machine);
            _context.SaveChanges();
        }

        public void DeleteMachine(int machineId)
        {
            _context.Machines.Remove(_context.Machines.SingleOrDefault(x => x.MachineId == machineId));
            _context.SaveChanges();
        }

        public MachineModel GetMachineById(int machineId)
        {
            return _context.Machines.Include(m => m.Services).SingleOrDefault(x => x.MachineId == machineId);
        }

        public IEnumerable<MachineModel> GetMachines()
        {
            return _context.Machines;
        }

        public IEnumerable<MachineModel> GetMachinesByFarmId(int farmId)
        {
            List<MachineModel> farmMachines = new List<MachineModel>();
            foreach (MachineModel machine in _context.Machines)
            {
                if (machine.FarmId == farmId)
                {
                    farmMachines.Add(machine);
                }
            }
            return farmMachines;
        }

        public void UpdateMachine(int machineId, MachineModel machine)
        {
            var result = _context.Machines.SingleOrDefault(x => x.MachineId == machineId);
            if (result != null)
            {
                result.Brand = machine.Brand;
                result.Model = machine.Model;
                result.ProductionYear = machine.ProductionYear;
                result.LastService = machine.LastService;
                _context.SaveChanges();
            }
        }

    }
}
