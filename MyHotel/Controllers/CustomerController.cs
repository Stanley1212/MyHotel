using Microsoft.AspNet.Identity;
using MyHotel.Services;
using MyHotel.Services.Interfaces;
using MyHotel.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyHotel.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private ICustomerService _CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var model = _CustomerService.GetAll();
            return View(model);
        }

        public ActionResult Table()
        {
            try
            {
                var model = _CustomerService.GetAll();
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
                var Bed = new CustomerViewModel();
                var model = CommonExtension.RenderRazorViewToString("_CreateCustomer", Bed, this);
                return Json(new { error = false, result = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CustomerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CommonExtension.Currentuser = User.Identity.GetUserName();
                    int result = 0;

                    if (model.CustomerID <= 0)
                        result = await _CustomerService.Insert(model);
                    else
                        result = await _CustomerService.Update(model);

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
                var Bed = _CustomerService.GetById(id);
                var model = CommonExtension.RenderRazorViewToString("_CreateCustomer", Bed, this);
                return Json(new { error = false, result = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
