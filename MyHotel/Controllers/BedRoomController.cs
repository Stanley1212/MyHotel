using Microsoft.AspNet.Identity;
using MyHotel.Services;
using MyHotel.Services.Interfaces;
using MyHotel.ViewModel.BedRoom;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyHotel.Controllers
{
    [Authorize]
    public class BedRoomController : Controller
    {
        private IBedRoomService _BedRoomService;

        public BedRoomController(IBedRoomService bedRoomService)
        {
            _BedRoomService = bedRoomService;
        }

        // GET: BedRoom
        public ActionResult Index()
        {
            var model = _BedRoomService.GetAll();
            return View(model);
        }

        public ActionResult Table()
        {
            try
            {
                var model = _BedRoomService.GetAll();
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
                var Bed = _BedRoomService.GetById(0);
                var model = CommonExtension.RenderRazorViewToString("_CreateBedRoom", Bed, this);
                return Json(new { error = false, result = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(BedRoomViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CommonExtension.Currentuser = User.Identity.GetUserName();
                    int result = 0;
                    if (model.BedRoomID <= 0)
                        result = await _BedRoomService.Insert(model);
                    else
                        result = await _BedRoomService.Update(model);

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
                var Bed = _BedRoomService.GetById(id);
                var model = CommonExtension.RenderRazorViewToString("_CreateBedRoom", Bed, this);
                return Json(new { error = false, result = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
