﻿using AgroApp.Models;
using AgroApp.Repositories;
using AgroApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AgroApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IFarmRepository _farmRepository;
        private readonly UserManager<UserModel> _userManager;

        public TaskController(ITaskRepository taskRepository, IFarmRepository farmRepository, UserManager<UserModel> userManager)
        {
            _taskRepository = taskRepository;
            _farmRepository = farmRepository;
            _userManager = userManager;
        }


        // GET: TaskController
        async public Task<ActionResult> Index()
        {
            if (User.IsInRole("Administrator"))
            {
                return View(_taskRepository.GetTasks());
            }
            else if (User.IsInRole("Farmer"))
            {

                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    FarmModel farm;
                    farm = _farmRepository.GetFarmByUserId(user.Id);
                    ViewBag.FarmId = farm.FarmId;
                    return View(_taskRepository.GetTasksByFarmId(_farmRepository.GetFarmByUserId(user.Id).FarmId));
                }
                catch
                {
                    return View();
                }
            }else if (User.IsInRole("Employee"))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                
                return View("IndexEmployee", _taskRepository.GetTasksByUserId(user.Id));
            }

            return View();
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            return View(_taskRepository.GetTaskById(id));
        }

        // GET: TaskController/Create
        public ActionResult Create(int id)
        {
            var farmUsersDictionary = new Dictionary<string, string>();
            foreach(UserModel user in _userManager.Users)
            {
                if(user.FarmId == id)
                {
                    farmUsersDictionary.Add(user.Id, user.Name);
                }
            }
            SelectList farmUsers = new SelectList(farmUsersDictionary, "Key", "Value");
            ViewBag.FarmId =  id;
            ViewBag.FarmUsers = farmUsers;
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel task)
        {
            try
            {
                task.CreateDate = DateTime.UtcNow;
                _taskRepository.AddTask(task);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/CreateForUser
        [HttpGet]
        async public Task<ActionResult> CreateForUser(string id)
        {
            ViewBag.UserId = id;
            var employee = _userManager.Users.FirstOrDefault(x => x.Id == id);
            if(employee != null)
            {
                ViewBag.FarmId = employee.FarmId;
            }
            else
            {
                ViewBag.FarmId = 0;
            }
            return View();
        }


        // POST: TaskController/CreateForUser
        [HttpPost]
        public ActionResult CreateForUser(TaskModel task)
        {
            try
            {
                task.CreateDate = DateTime.UtcNow;
                task.dateTime = null;
                _taskRepository.AddTask(task);
                return RedirectToAction(nameof(EmployeeTasks), new { id = task.UserId });
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_taskRepository.GetTaskById(id));
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel task)
        {
            try
            {
                _taskRepository.UpdateTask(id, task);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_taskRepository.GetTaskById(id));
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var task = _taskRepository.GetTaskById(id);
                _taskRepository.DeleteTask(id);
                return RedirectToAction(nameof(EmployeeTasks), new { id = task.UserId });
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult EmployeeTasks(string id)
        {
            ViewBag.UserId = id;
            return View(_taskRepository.GetTasksByUserId(id));
        }
    }
}
