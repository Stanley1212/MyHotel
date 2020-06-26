using Autofac;
using MyHotel.Services;
using MyHotel.Services.Interfaces;

namespace MyHotel.Infrastructure.Ioc
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LevelRoomService>().As<ILevelRoomService>();
            builder.RegisterType<TypeRoomService>().As<ITypeRoomService>();
            builder.RegisterType<BedRoomService>().As<IBedRoomService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<ReceptionsService>().As<IReceptionsService>();
        }
    }
}
