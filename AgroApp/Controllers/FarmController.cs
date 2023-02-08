using AgroApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgroApp.Models;
using System.Dynamic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using AgroApp.Repositories.Interfaces;
using System.Collections;

namespace AgroApp.Controllers
{
    public class FarmController : Controller
    {
        private readonly IFarmRepository _farmRepository;
        private readonly IFieldRepository _fieldRepository;
        private readonly IMachineRepository _machineRepository;
        private readonly UserManager<UserModel> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public FarmController(IFarmRepository farmRepository, IFieldRepository fieldRepository, UserManager<UserModel> userManager,
            IMachineRepository machineRepository, RoleManager<IdentityRole> roleManager)
        {
            _farmRepository = farmRepository;
            _userManager = userManager;
            _fieldRepository = fieldRepository;
            _machineRepository = machineRepository;
            _roleManager = roleManager;
        }

        [Authorize]
        // GET: FarmController
        public async Task<ActionResult> Index()
        {
            if (User.IsInRole("Administrator"))
            {
                var FarmList = _farmRepository.GetFarms();
                return View(FarmList);
            }else if (User.IsInRole("Farmer"))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                List<FarmModel> farms = new List<FarmModel>();
                FarmModel farm = _farmRepository.GetFarmByUserId(user.Id);
                
                if (farm != null)
                {
                    farms.Add(farm);
                    return View(farms);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        

            // GET: FarmController/Details/5
            public async Task<ActionResult> Details(int id)
        {
            if (User.IsInRole("Administrator"))
            {
                List<UserModel> employees = new List<UserModel>();

                ViewBag.Employees = employees;
                var farm = _farmRepository.GetFarmById(id);
                return View(farm);
            }else if (User.IsInRole("Farmer"))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                try
                {
                    FarmModel farm;
                    farm = _farmRepository.GetFarmByUserId(user.Id);
                    var fieldList = _fieldRepository.GetFieldsByFarmId(farm.FarmId);
                    double area = 0;
                    ViewBag.FieldCount = fieldList.Count().ToString();
                    foreach(var field in fieldList)
                    {
                        area += field.Area;
                    }
                    ViewBag.AreaCount = area.ToString();

                    return View(farm);
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        [Authorize(Roles = "Administrator")]
        // GET: FarmController/Create
        public async Task<ActionResult> Create()
        {
            List<SelectListItem> result = await getUsersById2();
            ViewBag.Users = result;
            return View();
        }
        [Authorize(Roles = "Administrator")]
        // POST: FarmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FarmModel farmModel)
        {
            if(farmModel.FarmOwnerId != null)
            {
                var owner = await _userManager.FindByIdAsync(farmModel.FarmOwnerId);
                farmModel.FarmOwnerName = owner.Name + " " + owner.Surname;
            }
            _farmRepository.AddFarm(farmModel);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrator")]
        // GET: FarmController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            FarmModel Farm = _farmRepository.GetFarmById(id);

            if (Farm != null)
            {
                List<SelectListItem> result = await getUsersById2();
                ViewBag.Users = result;

                return View(Farm);
            }

            return View();
        }

        [Authorize(Roles = "Administrator")]
        // POST: FarmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id, FarmModel farmModel)
        {
            if (farmModel != null)
            {
                try
                {
                    if (farmModel.FarmOwnerId != null)
                    {
                        var owner = await _userManager.FindByIdAsync(farmModel.FarmOwnerId);
                        farmModel.FarmOwnerName = owner.Name + " " + owner.Surname;
                    }
                    _farmRepository.UpdateFarm(id, farmModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }


        [Authorize(Roles = "Administrator")]
        // GET: FarmController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Users = getUsersById();
            return View(_farmRepository.GetFarmById(id));
        }

        [Authorize(Roles = "Administrator")]
        // POST: FarmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FarmModel farmModel)
        {
            try
            {
                foreach(UserModel user in _userManager.Users)
                {
                    if(user.FarmId == id)
                    {
                        user.FarmId = null;
                    }
                }
                foreach(var machine in _machineRepository.GetMachines())
                {
                    if(machine.FarmId == id)
                    {
                        _machineRepository.DeleteMachine(machine.MachineId);
                    }
                }
                _farmRepository.DeleteFarm(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                
                return View(e.Message);
            }
        }

        private List<SelectListItem> getUsersById()
        {
            var userList = _userManager.Users;
            var usersListItem = new List<SelectListItem>();
            //null nie działa - Przekazywany jest tekst
            usersListItem.Add(new SelectListItem { Value = "", Text = "Brak" });

            foreach (UserModel user in userList)
            {
                usersListItem.Add(new SelectListItem { Value = user.Id, Text = user.Name + " " + user.Surname });
            }
            return usersListItem;
        }

        private async Task<List<SelectListItem>> getUsersById2()
        {
            var farmList = _farmRepository.GetFarms();
            var userIdFromFarms = new List<String>();
            var userList = _userManager.Users;
            
            var usersListItem = new List<SelectListItem>();
            //null nie działa - Przekazywany jest tekst
            usersListItem.Add(new SelectListItem { Value = "", Text = "Brak" });
            foreach(FarmModel farm in farmList)
            {
                if (farm.FarmOwnerId != null)
                {
                    userIdFromFarms.Add(farm.FarmOwnerId);
                }
            }

            foreach (UserModel user in userList)
            {
                Boolean isBusy = false;
                foreach(String id in userIdFromFarms)
                {
                    if (user.Id == id)
                    {
                        isBusy = true;
                    }
                }
                if (isBusy == false)
                {
                    if (await _userManager.IsInRoleAsync(user, "Farmer"))
                     {
                        usersListItem.Add(new SelectListItem { Value = user.Id, Text = user.Name + " " + user.Surname });
                    }
                }
            }
            //List<SelectListItem> castList = usersListItem.Cast<SelectListItem>().ToList();
            //return outputUserList.;
            return usersListItem;
            //return database.Table<Patient>().ToListAsync();
            // await Task.FromResult(doctors)
            // List<Y> listOfY = listOfX.Cast<Y>().ToList();
        }

        public ActionResult FarmInfoPartial()
        {
                return PartialView("~/Views/Farm/_FarmInfo");
        }
    }
}
