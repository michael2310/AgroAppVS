using AgroApp.Models;

namespace AgroApp.Repositories.Interfaces
{
    public interface IMachineRepository
    {
        MachineModel GetMachineById(int machineId);
        IEnumerable<MachineModel> GetMachines();
        IEnumerable<MachineModel> GetMachinesByFarmId(int farmId);
        void AddMachine(MachineModel machine);
        void UpdateMachine(int machineId, MachineModel machine);
        void DeleteMachine(int machineId);
    }
}
