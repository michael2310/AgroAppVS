using AgroApp.Data;
using AgroApp.Models;
using AgroApp.Repositories.Interfaces;

namespace AgroApp.Repositories
{
    public class MachineServiceRepository : IMachineServiceRepository
    {

        private readonly ApplicationDbContext _context;

        public MachineServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddService(MachineServiceModel service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void DeleteService(int serviceId)
        {
            var result = _context.Services.SingleOrDefault(x => x.ServiceId == serviceId);
            if (result != null)
            {
                _context.Services.Remove(result);
            }

            _context.SaveChanges();
        }

        public MachineServiceModel GetServiceById(int serviceId)
        {
            return _context.Services.SingleOrDefault(x => x.ServiceId == serviceId);
        }

        public IEnumerable<MachineServiceModel> GetServices()
        {
            return _context.Services.ToList();
        }

        public IEnumerable<MachineServiceModel> GetServicesByMachineId(int machineId)
        {
            var id = machineId;
            List<MachineServiceModel> services = new();
            foreach (MachineServiceModel service in this.GetServices())
            {
                if (service.MachineId == machineId)
                {
                    services.Add(service);
                }
            }
            return services;
        }

        public void UpdateService(int serviceId, MachineServiceModel service)
        {
            var result = _context.Services.SingleOrDefault(x => x.ServiceId == serviceId);
            if (result != null)
            {
                result.ServiceDate = service.ServiceDate;
                result.ServiceInfo = service.ServiceInfo;

                _context.SaveChanges();
            }
        }
    }
}
