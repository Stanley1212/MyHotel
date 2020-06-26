using AutoMapper;
using MyHotel.Domain;
using MyHotel.Repository.Interfaces;
using MyHotel.Services.Interfaces;
using MyHotel.ViewModel.TypeRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Services
{
    public class TypeRoomService : ITypeRoomService
    {
        private ITypeRoomRepository _Repository;
        private IMapper _Mapper;

        public TypeRoomService(ITypeRoomRepository typeRoomRepository,IMapper mapper)
        {
            _Repository = typeRoomRepository;
            _Mapper = mapper;
        }

        public IEnumerable<TypeRoomViewModel> GetAll()
        {

            var List = _Mapper.Map<IEnumerable<TypeRoomViewModel>>(_Repository.GetAll());

            return List;
        }

        public TypeRoomViewModel GetById(int id)
        {
            var model =_Mapper.Map<TypeRoomViewModel>(_Repository.GetById(id));
            return model;
        }

        public Task<int> Insert(TypeRoomViewModel model)
        {
            var Room = _Mapper.Map<TypeRoom>(model);
            Room.CreateDate = DateTime.UtcNow;
            Room.CreateUser = CommonExtension.Currentuser;


            return _Repository.Insert(Room);
        }

        public Task<int> Update(TypeRoomViewModel model)
        {
            var Room = _Mapper.Map<TypeRoom>(model);
            Room.UpdateDate = DateTime.UtcNow;
            Room.UpdateUser = CommonExtension.Currentuser;


            return _Repository.Update(Room);
        }
    }
}
