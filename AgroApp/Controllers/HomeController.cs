using AgroApp.Models;
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

        public HomeController(ILogger<HomeController> logger, UserManager<UserModel> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        
        [Authorize(Roles = "Farmer, Administrator")]
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


        public PartialViewResult FarmInfoPartial()
        {
            return PartialView("_FarmInfo");
        }
    }
}