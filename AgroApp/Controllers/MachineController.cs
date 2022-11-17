using AgroApp.Models;
using AgroApp.Repositories;
using AgroApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgroApp.Controllers
{
    [Authorize]
    public class MachineController : Controller
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IFarmRepository _farmRepository;
        private readonly UserManager<UserModel> _userManager;

        public MachineController(IMachineRepository machineRepository, IFarmRepository farmRepository, UserManager<UserModel> userManager)
        {
            _machineRepository = machineRepository;
            _farmRepository = farmRepository;
            _userManager = userManager;
        }
        // GET: MachineController
        async public Task<ActionResult> Index()
        {
            if (User.IsInRole("Administrator"))
            {
                return View(_machineRepository.GetMachines());
            }
            else if (User.IsInRole("Farmer"))
            {
                
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    FarmModel farm;
                    farm = _farmRepository.GetFarmByUserId(user.Id);
                    ViewBag.FarmId = farm.FarmId;
                    return View(_machineRepository.GetMachinesByFarmId(_farmRepository.GetFarmByUserId(user.Id).FarmId));
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        // GET: MachineController/Details/5
        public ActionResult Details(int id)
        {
            return View(_machineRepository.GetMachineById(id));
        }

        // GET: MachineController/Create
        public ActionResult Create(int id)
        {
            ViewBag.FarmId = id;
            return View();
        }

        // POST: MachineController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MachineModel machine)
        {
            try
            {
                _machineRepository.AddMachine(machine);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MachineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_machineRepository.GetMachineById(id));
        }

        // POST: MachineController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MachineModel machine)
        {
            try
            {
                _machineRepository.UpdateMachine(id, machine);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MachineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_machineRepository.GetMachineById(id));
        }

        // POST: MachineController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MachineModel machine)
        {
            try
            {
                _machineRepository.DeleteMachine(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
