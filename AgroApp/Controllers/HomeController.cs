using AgroApp.Models;
using AgroApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgroApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<UserModel> _userManager;
        private readonly IFarmRepository _farmRepository;

        public HomeController(ILogger<HomeController> logger, UserManager<UserModel> userManager, IFarmRepository farmRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _farmRepository = farmRepository;
           
        }
        
        [Authorize(Roles = "Farmer, Administrator, Employee")]
        public async Task<IActionResult> Index()
        {
            UserModel user = await _userManager.GetUserAsync(HttpContext.User);
            string message = user.UserName;
            return View((object)message);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<PartialViewResult> FarmInfoPartial()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return PartialView("InfoFarmPartial", _farmRepository.GetFarmByUserId(user.Id));
        }

        public IActionResult part()
        {
            ViewBag.HEHE = "HEHE";
            return PartialView("_part");
        }
    }
}