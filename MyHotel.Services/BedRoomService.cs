using AutoMapper;
using MyHotel.Domain;
using MyHotel.Infrastructure;
using MyHotel.Repository.Interfaces;
using MyHotel.Services.Interfaces;
using MyHotel.ViewModel.BedRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Services
{
    public class BedRoomService : IBedRoomService
    {
        private IBedRoomRepository _Repository;
        private IMapper _Mapper;
        private ITypeRoomService _TypeRoomService;
        private ILevelRoomService _LevelRoomService;

        public BedRoomService(IBedRoomRepository bedRoomRepository,IMapper mapper,ITypeRoomService typeRoomService,ILevelRoomService levelRoomService)
        {
            _Repository = bedRoomRepository;
            _Mapper = mapper;
            _TypeRoomService = typeRoomService;
            _LevelRoomService = levelRoomService;
        }

        public IEnumerable<BedRoomListViewModel> GetAll()
        {
            var model = _Repository.GetAll(includeProperties: "TypeRoom,Level");
            var list = _Mapper.Map<List<BedRoomListViewModel>>(model);

            return list;
        }

        public BedRoomViewModel GetById(int id)
        {
            BedRoomViewModel bedRoom = new BedRoomViewModel();

            if (id > 0)
                bedRoom = _Mapper.Map<BedRoomViewModel>(_Repository.GetById(id));

            bedRoom.Levels = _LevelRoomService.GetAll();
            bedRoom.TypeRooms = _TypeRoomService.GetAll();


            return bedRoom;
        }

        public Task<int> Insert(BedRoomViewModel model)
        {
            var modelToSave = _Mapper.Map<BedRoom>(model);
            modelToSave.CreateDate = DateTime.UtcNow;
            modelToSave.CreateUser = CommonExtension.Currentuser;

            return _Repository.Insert(modelToSave);
        }

        public Task<int> Update(BedRoomViewModel model)
        {
            var Room = _Mapper.Map<BedRoom>(model);
            Room.UpdateDate = DateTime.UtcNow;
            Room.UpdateUser = CommonExtension.Currentuser;


            return _Repository.Update(Room);
        }

        IEnumerable<BedRoomViewModel> IServiceBase<BedRoomViewModel>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
