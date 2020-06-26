using AutoMapper;
using MyHotel.Domain;
using MyHotel.ViewModel.BedRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Services.Mapper
{
    public class BedRoomProfile:Profile
    {
        public BedRoomProfile()
        {
            CreateMap<BedRoom, BedRoomViewModel>().ReverseMap();
            CreateMap<BedRoom, BedRoomListViewModel>()
                .ForMember(dest=>dest.LevelName,act=> act.MapFrom(s=>s.Level.Name))
                .ForMember(dest=>dest.TypeRoomName,act=> act.MapFrom(s=>s.TypeRoom.Name)).ReverseMap();
        }
    }
}
