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
    public class BedRoomRepository:GenericRepository<BedRoom>,IBedRoomRepository
    {
        public BedRoomRepository(Infrastructure.Data.ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
                
        }
    }
}
