using Microsoft.AspNet.Identity;
using MyHotel.Services;
using MyHotel.Services.Interfaces;
using MyHotel.ViewModel.LevelRoom;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyHotel.Controllers
{
    [Authorize]
    public class LevelRoomController : Controller
    {
        ILevelRoomService _levelRoomService;

        public LevelRoomController(ILevelRoomService levelRoomService)
        {
            _levelRoomService = levelRoomService;
        }

        // GET: LivelRoom
        public ActionResult Index()
        {
            var model = _levelRoomService.GetAll();
            return View(model);
        }

        public ActionResult Table()
        {
            var model = _levelRoomService.GetAll();
            var view = CommonExtension.RenderRazorViewToString("Table", model, this);

            return Json(new { error = false, result = view }, JsonRequestBehavior.AllowGet);
        }


        // GET: LivelRoom/Create
        public ActionResult Create()
        {
            try
            {

                var Level = new LevelRoomViewModel();
               

                var model = CommonExtension.RenderRazorViewToString("_CreateLevelRoom", Level, this);
                return Json(new { error = false, result = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: LivelRoom/Create
        [HttpPost]
        public async Task<ActionResult> Create(LevelRoomViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CommonExtension.Currentuser = User.Identity.GetUserName();
                    int result = 0;
                    if (model.LevelID <= 0)
                        result = await _levelRoomService.Insert(model);
                    else
                        result = await _levelRoomService.Update(model);

                    return Json(new { error = false, result = "Registro guardado correctamente !" }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { error = true, result = "Error en el modelo, favor validar los campos" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: LivelRoom/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {

                var Level = new LevelRoomViewModel();
                Level = _levelRoomService.GetById(id);

                var model = CommonExtension.RenderRazorViewToString("_CreateLevelRoom", Level, this);
                return Json(new { error = false, result = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: LivelRoom/Edit/5
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

        // GET: LivelRoom/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LivelRoom/Delete/5
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
