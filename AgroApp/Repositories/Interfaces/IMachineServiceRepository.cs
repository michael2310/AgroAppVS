using AgroApp.Models;

namespace AgroApp.Repositories.Interfaces
{
    public interface IMachineServiceRepository
    {
            MachineServiceModel GetServiceById(int serviceId);
            IEnumerable<MachineServiceModel> GetServicesByMachineId(int machineId);
            IEnumerable<MachineServiceModel> GetServices();
            void AddService(MachineServiceModel service);
            void UpdateService(int serviceId, MachineServiceModel service);
            void DeleteService(int serviceId);
        
    }
}
