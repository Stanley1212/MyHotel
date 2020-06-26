using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyHotel.Services
{
    public static class CommonExtension
    {
        public static string Currentuser;
        public static IMapper ConfigurationAutomapper(this AppDomain domain)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(domain.GetReferenceAssemblies());
            });


            return mapperConfiguration.CreateMapper();
        }

        public static Assembly[] GetReferenceAssemblies(this AppDomain appDomain)
        {
            Assembly assemblyLocal = Assembly.GetEntryAssembly();

            if (assemblyLocal != null)
                LoadRefernceAssamblies(assemblyLocal);

            return appDomain.GetAssemblies().Where(a => !a.FullName.StartsWith("System")
                                                            && !a.FullName.StartsWith("Microsoft")).ToArray();
        }

        private static void LoadRefernceAssamblies(Assembly assembly)
        {
            foreach (AssemblyName assemblyName in assembly.GetReferencedAssemblies()
                                                            .Where(a => !a.FullName.StartsWith("System")
                                                            && !a.FullName.StartsWith("Microsoft")).ToArray())
            {
                if (AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName == assemblyName.FullName))
                    Assembly.Load(assemblyName);

            }
        }

        public static string RenderRazorViewToString(string viewName, object model, Controller controller)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View,
                                             controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
