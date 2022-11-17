using AgroApp.Models;
using AgroApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroApp.Controllers
{
    public class EntryController : Controller
    { 

        private readonly IEntryRepository _entryRepository;

        public EntryController(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }
        // GET: EntryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EntryController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Id = id;
            return View(_entryRepository.GetEntriesByFieldId(id));
        }

        // GET: EntryController/Create
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // POST: EntryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntryModel entryModel)
        {
            try
            {
                _entryRepository.AddEntry(entryModel);
                return RedirectToAction("Details", new {id = entryModel.FieldId });
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: EntryController/Edit/5
        public ActionResult Edit(int id)
        {
            

            return View();
        }

        // POST: EntryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EntryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
