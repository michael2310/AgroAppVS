using AgroApp.Models;
using AgroApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgroApp.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private IPasswordHasher<UserModel> _passwordHasher;
        private IFarmRepository _farmRepository;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager,
            IPasswordHasher<UserModel> passwordHasher, IFarmRepository farmRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _farmRepository = farmRepository;
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        
        public IActionResult Index()
        {
            return View(_userManager.Users);
                }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _userManager.FindByNameAsync(loginModel.Login);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginModel.Login, loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(nameof(loginModel.Password), "Niepoprawny login lub hasło");
            }
            return View(loginModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
           /* var farmlist = _farmRepository.GetFarms();
            var farmnames = new List<string>();
            foreach(FarmModel farmModel in farmlist)
            {
                farmnames.Add(farmModel.FarmName);
            }
            IEnumerable<string> list = farmnames;

            var FarmSelectList = new SelectList(_farmRepository.GetFarms(), nameof(FarmModel.FarmName));

            SelectList selectListItems = new SelectList(list);
           */



            var farmlist = _farmRepository.GetFarms();
            var farmsDictionary = new Dictionary<int, string>();
            //null nie działa - Przekazywany jest tekst
            farmsDictionary.Add(0, "brak");

            foreach (FarmModel farm in farmlist)
            {
                farmsDictionary.Add(farm.FarmId, farm.FarmName);
            }

            SelectList farmsSelectList = new SelectList(farmsDictionary, "Key", "Value");

            ViewBag.Farms = farmsSelectList;
            //ViewBag.Farms = FarmSelectList;


            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel registerModel, string farmName)
        {

            //if (ModelState.IsValid)
            {
                UserModel newUser = new()
                {
                    Name = registerModel.Name,
                    Surname = registerModel.Surname,
                    Email = registerModel.Email,
                    UserName = registerModel.UserName,
                    Position = registerModel.Position
                    
                    //,

                    //Farm = _farmRepository.GetFarmByName(registerModel.FarmName)
                };

              //  if (_farmRepository.GetFarmByName(registerModel.FarmName) != null) {
              //      newUser.Farm = _farmRepository.GetFarmByName(registerModel.FarmName);
               // }
               // else
               // {
               //     newUser.Farm = null;
               // }

                if(_farmRepository.GetFarmById(registerModel.FarmId) != null)
                {
                    newUser.Farm = _farmRepository.GetFarmById(registerModel.FarmId);
                }
                else
                {
                    newUser.Farm = null;
                }

              IdentityResult result = await _userManager.CreateAsync(newUser, registerModel.Password);

                if(result.Succeeded)
                    return RedirectToAction("Index", "Account");
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(registerModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            UserModel user = await _userManager.FindByIdAsync(id);

            //ViewData do gospodarstw
           

           
            if (user == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                RegisterModel registerModel = new RegisterModel()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    Email = user.Email,
                    Position = user.Position,
                    FarmId = user.FarmId
                };


                var farmlist = _farmRepository.GetFarms();
                var farmsDictionary = new Dictionary<int, string>();
                //null nie działa - Przekazywany jest tekst
                farmsDictionary.Add(0, "brak");

                foreach (FarmModel farm in farmlist)
                {
                    farmsDictionary.Add(farm.FarmId, farm.FarmName);
                }

                SelectList farmsSelectList = new SelectList(farmsDictionary, "Key", "Value");

                ViewBag.Farms = farmsSelectList;


                return View(registerModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegisterModel registerModel, string id, string email, string password)
        {
            UserModel user = await _userManager.FindByIdAsync(id);
            if(user != null) {
                /* if (!string.IsNullOrEmpty(email))
                 {
                     user.Email = email;
                 }
                 else
                 {
                     ModelState.AddModelError("", "Email cannot be empty");
                 }
                 if (!string.IsNullOrEmpty(password))
                 {
                     user.PasswordHash = _passwordHasher.HashPassword(user, password);
                 }
                 else
                 {
                     ModelState.AddModelError("", "Password cannot be empty");
                 }
                 if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                 {
                     IdentityResult result = await _userManager.UpdateAsync(user);
                     if (result.Succeeded)
                     {
                         return RedirectToAction("Index");
                     }
                     else
                     {
                         Errors(result);
                     }
            }
            */
                user.Name = registerModel.Name;
                user.Surname = registerModel.Surname;
                user.UserName = registerModel.UserName;
                user.Position = registerModel.Position;
                user.Email = registerModel.Email;
                user.PasswordHash = _passwordHasher.HashPassword(user, registerModel.Password);


                if (_farmRepository.GetFarmById(registerModel.FarmId) != null)
                {
                    user.Farm = _farmRepository.GetFarmById(registerModel.FarmId);
                }
                else
                {
                    user.Farm = null;
                }

                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Errors(result);
                }

            }
            else
                ModelState.AddModelError("", "User not found");
                return RedirectToAction("Index");
            
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            UserModel user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Errors(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
                return View("Index", _userManager.Users);
            }
            return View("Index", _userManager.Users);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }

}
