using AgroApp.Models;
using AgroApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace AgroApp.Controllers
{
    [Authorize]
    public class FieldController : Controller
    {

        private readonly IFieldRepository _fieldRepository;
        private readonly IFarmRepository _farmRepository;
        private readonly UserManager<UserModel> _userManager;

        public FieldController(IFieldRepository fieldRepository, IFarmRepository farmRepository,UserManager<UserModel> userManager)
        {
            _fieldRepository = fieldRepository;
            _farmRepository = farmRepository;
            _userManager = userManager;
        }

        
        // GET: FieldController
        async public Task<ActionResult> Index(int id)
        {
            if (User.IsInRole("Administrator"))
            {
                return View(_fieldRepository.GetFields());
            }else if (User.IsInRole("Farmer"))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                try
                {
                    FarmModel farm;
                    farm = _farmRepository.GetFarmByUserId(user.Id);
                    ViewBag.FarmId = farm.FarmId;
                    return View(_fieldRepository.GetFieldsByFarmId(farm.FarmId));
                }
                catch {
                    return View();
                }
            }
            
                return View();
        }


            // GET: FieldController/Details/5
            public ActionResult Details(int id){
            ViewBag.FieldId = id;
            return View(_fieldRepository.GetFieldById(id));
           /* if (id != 0)
            {
                return PartialView(_fieldRepository.GetFieldById(id));
            }
            else
            {
                return 
            }*/
        }


        // GET: FieldController/Create
        public ActionResult Create(int id)
        {
            ViewBag.FarmId = id;
            return View();
        }

        // POST: FieldController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FieldModel fieldModel)
        {
            _fieldRepository.AddField(fieldModel);
            return RedirectToAction(nameof(Index));
      
        }

        // GET: FieldController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_fieldRepository.GetFieldById(id));
        }

        // POST: FieldController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FieldModel fieldModel)
        {
           _fieldRepository.UpdateField(id, fieldModel);

           return RedirectToAction(nameof(Index));
        }

        // GET: FieldController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_fieldRepository.GetFieldById(id));
        }

        // POST: FieldController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FieldModel fieldModel)
        {
            _fieldRepository.DeleteField(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
