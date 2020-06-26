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
    public class LevelRoomRepository : GenericRepository<LevelRoom>, ILevelRoomRepository
    {
        public LevelRoomRepository(Infrastructure.Data.ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }
    }
}
