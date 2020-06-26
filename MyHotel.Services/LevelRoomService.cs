using AutoMapper;
using MyHotel.Domain;
using MyHotel.Infrastructure;
using MyHotel.Repository.Interfaces;
using MyHotel.Services.Interfaces;
using MyHotel.ViewModel.LevelRoom;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MyHotel.Services
{
    public class LevelRoomService : ILevelRoomService
    {
        ILevelRoomRepository _LevelRepository;
        IMapper _IMapper;

        public LevelRoomService(ILevelRoomRepository levelRepository,IMapper mapper)
        {
            _LevelRepository = levelRepository;
            _IMapper = mapper;
        }

        public IEnumerable<LevelRoomViewModel> GetAll()
        {
            var ListModel = _IMapper.Map<IEnumerable<LevelRoomViewModel>>(_LevelRepository.GetAll());
            return ListModel;
        }

        public async Task<int> Update(LevelRoomViewModel model)
        {
            var levelRoom = _IMapper.Map<LevelRoom>(model);
            levelRoom.UpdateDate = DateTime.UtcNow;
            levelRoom.UpdateUser = CommonExtension.Currentuser;


            return await _LevelRepository.Update(levelRoom);
        }

        public LevelRoomViewModel GetById(int id)
        {
            var model = _IMapper.Map<LevelRoomViewModel>(_LevelRepository.GetById(id));
            return model;
        }

        public async Task<int> Insert(LevelRoomViewModel model)
        {
            var levelRoom = _IMapper.Map<LevelRoom>(model);
            levelRoom.CreateDate = DateTime.UtcNow;
            levelRoom.CreateUser = CommonExtension.Currentuser;
            

            return await _LevelRepository.Insert(levelRoom);
        }

       
    }
}
