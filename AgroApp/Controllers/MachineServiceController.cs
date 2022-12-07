using AgroApp.Models;
using AgroApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroApp.Controllers
{
    public class MachineServiceController : Controller
    {

        private readonly IMachineServiceRepository _machineServiceRepository;

        public MachineServiceController(IMachineServiceRepository machineServiceRepository)
        {
            _machineServiceRepository = machineServiceRepository;
        }

        // GET: MachineServiceController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MachineServiceController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Id = id;
            return View(_machineServiceRepository.GetServiceById(id));
        }

        // GET: MachineServiceController/Create
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // POST: MachineServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MachineServiceModel machineServiceModel)
        {
            try
            {
                _machineServiceRepository.AddService(machineServiceModel);
                return RedirectToAction("Details","Machine", new { id = machineServiceModel.MachineId });
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: MachineServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = _machineServiceRepository.GetServiceById(id);
            return View(_machineServiceRepository.GetServiceById(id));
        }

        // POST: MachineServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MachineServiceModel machineServiceModel)
        {
            try
            {
                _machineServiceRepository.UpdateService(id, machineServiceModel);
                return RedirectToAction("Details", "Machine", new { id = machineServiceModel.MachineId });
            }
            catch
            {
                return View();
            }
        }

        // GET: MachineServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_machineServiceRepository.GetServiceById(id));
        }

        // POST: MachineServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MachineServiceModel machineServiceModel)
        {
            try
            {
                var machineId = _machineServiceRepository.GetServiceById(id).MachineId;
                _machineServiceRepository.DeleteService(id);
                return RedirectToAction(nameof(Details), "Machine", new { id = machineId });
            }
            catch
            {
                return View();
            }
        }
    }
}
