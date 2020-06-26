using Autofac;
using MyHotel.Infrastructure.Data;
using MyHotel.Repository;
using MyHotel.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Infrastructure.Ioc
{
   public class RepositoryModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();
            builder.RegisterType<LevelRoomRepository>().As<ILevelRoomRepository>();
            builder.RegisterType<TypeRoomRepository>().As<ITypeRoomRepository>();
            builder.RegisterType<BedRoomRepository>().As<IBedRoomRepository>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<ReceptionsRepository>().As<IReceptionsRepository>();
        }
    }
}
