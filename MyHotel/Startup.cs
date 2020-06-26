using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Owin;
using MyHotel.Infrastructure.Ioc;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHotel.Startup))]
namespace MyHotel
{
    public partial class Startup
    {       
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);          
        }
    }
}
