﻿using AgroApp.Models;
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
            return View(_entryRepository.GetEntryById(id));
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

            var res = _entryRepository.GetEntryById(id);
            return View(_entryRepository.GetEntryById(id));
        }

        // POST: EntryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EntryModel entry)
        {
            try
            {
                _entryRepository.UpdateEntry(id, entry);
                return RedirectToAction("Details", "Field", new { id = entry.FieldId });
            }
            catch
            {
                return View();
            }
        }

        // GET: EntryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_entryRepository.GetEntryById(id));
        }

        // POST: EntryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var fieldId = _entryRepository.GetEntryById(id).FieldId;
                _entryRepository.DeleteEntry(id);
                return RedirectToAction(nameof(Details), "Field", new {id = fieldId} );
            }
            catch
            {
                return View();
            }
        }
    }
}
