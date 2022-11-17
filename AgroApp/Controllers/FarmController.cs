using AgroApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgroApp.Models;
using System.Dynamic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace AgroApp.Controllers
{
    public class FarmController : Controller
    {
        private readonly IFarmRepository _farmRepository;
        private readonly UserManager<UserModel> _userManager;
       
        public FarmController(IFarmRepository farmRepository, UserManager<UserModel> userManager)
        {
            _farmRepository = farmRepository;
            _userManager = userManager;
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

                return View(_farmRepository.GetFarmById(id));
            }else if (User.IsInRole("Farmer"))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                try
                {
                    FarmModel farm;
                    farm = _farmRepository.GetFarmByUserId(user.Id);
                    
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
        public ActionResult Create()
        {
            ViewBag.Users = getUsersById();
            return View();
        }
        [Authorize(Roles = "Administrator")]
        // POST: FarmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FarmModel farmModel)
        {
            
            _farmRepository.AddFarm(farmModel);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrator")]
        // GET: FarmController/Edit/5
        public ActionResult Edit(int id)
        {
            FarmModel Farm = _farmRepository.GetFarmById(id);

            if (Farm != null)
            {
              
                ViewBag.Users = getUsersById();

                return View(Farm);
            }

            return View();
        }

        [Authorize(Roles = "Administrator")]
        // POST: FarmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FarmModel farmModel)
        {
            if (farmModel != null)
            {
                try
                {
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
            return View();
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

        public ActionResult FarmInfoPartial()
        {
                return PartialView("~/Views/Farm/_FarmInfo");
        }
    }
}
