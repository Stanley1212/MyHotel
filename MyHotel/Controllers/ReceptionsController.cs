using MyHotel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHotel.Controllers
{
    public class ReceptionsController : Controller
    {
        private IReceptionsService _ReceptionsSertvice;
        private IBedRoomService _BedRoomService;

        public ReceptionsController(IReceptionsService receptionsService,IBedRoomService bedRoomService)
        {
            _ReceptionsSertvice = receptionsService;
            _BedRoomService = bedRoomService;
        }

        // GET: Receptions
        public ActionResult Index()
        {
            var model = _BedRoomService.GetAll();
            return View(model);
        }

        // GET: Receptions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Receptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receptions/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Receptions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Receptions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Receptions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Receptions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
