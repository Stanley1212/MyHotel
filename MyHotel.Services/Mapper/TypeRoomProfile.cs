using AutoMapper;
using MyHotel.Domain;
using MyHotel.ViewModel.TypeRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Services.Mapper
{
    public class TypeRoomProfile:Profile
    {
        public TypeRoomProfile()
        {
            CreateMap<TypeRoom, TypeRoomViewModel>().ReverseMap();
        }
    }
}
