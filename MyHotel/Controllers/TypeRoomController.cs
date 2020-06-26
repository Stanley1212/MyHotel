using Microsoft.AspNet.Identity;
using MyHotel.Services;
using MyHotel.Services.Interfaces;
using MyHotel.ViewModel.TypeRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyHotel.Controllers
{
    [Authorize]
    public class TypeRoomController : Controller
    {
        private ITypeRoomService _typeRoomService;

        public TypeRoomController(ITypeRoomService typeRoomService)
        {
            _typeRoomService = typeRoomService;
        }

        // GET: TypeRoom
        public ActionResult Index()
        {
            var model = _typeRoomService.GetAll();
            return View(model);
        }

        public ActionResult Table()
        {
            try
            {
                var model = _typeRoomService.GetAll();
                var view = CommonExtension.RenderRazorViewToString("_Table", model, this);

                return Json(new { error = false, result = view }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Create()
        {
            try
            {
                var Type = new TypeRoomViewModel();
                var model = CommonExtension.RenderRazorViewToString("_CreateTypeRoom", Type, this);
                return Json(new { error = false, result = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(TypeRoomViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CommonExtension.Currentuser = User.Identity.GetUserName();
                    int result = 0;
                    if (model.TypeRoomID <= 0)
                        result = await _typeRoomService.Insert(model);
                    else
                        result = await _typeRoomService.Update(model);

                    return Json(new { error = false, result = "Registro guardado correctamente !" }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { error = true, result = "Error en el modelo, favor validar los campos" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {

                var Type = new TypeRoomViewModel();
                Type = _typeRoomService.GetById(id);

                var model = CommonExtension.RenderRazorViewToString("_CreateTypeRoom", Type, this);
                return Json(new { error = false, result = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        
        // GET: TypeRoom/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypeRoom/Delete/5
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
