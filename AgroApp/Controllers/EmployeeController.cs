using AgroApp.Models;
using AgroApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgroApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFarmRepository _farmRepository;
        private readonly UserManager<UserModel> _userManager;

        public EmployeeController(IEmployeeRepository employeeRepository, IFarmRepository farmRepository, UserManager<UserModel> userManager)
        {
            _employeeRepository = employeeRepository;
            _farmRepository = farmRepository;
            _userManager = userManager;
        }

        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(_employeeRepository.GetEmployeesByFarmId(_farmRepository.GetFarmByUserId(user.Id).FarmId));
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_employeeRepository.GetEmployeeById(id));
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View(new EmployeeModel());
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employee)
        {
            _employeeRepository.AddEmployee(employee);
            return RedirectToAction(nameof(Index));

        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_employeeRepository.GetEmployeeById(id));
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeModel employee)
        {
            _employeeRepository.UpdateEmployee(id, employee);
            return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_employeeRepository.GetEmployeeById(id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
