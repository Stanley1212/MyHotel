using MyHotel.Domain;
using MyHotel.Infrastructure;
using MyHotel.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Repository
{
    public class TypeRoomRepository : GenericRepository<TypeRoom>,ITypeRoomRepository
    {

        public TypeRoomRepository(Infrastructure.Data.ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

    }
}
