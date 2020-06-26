using AutoMapper;
using MyHotel.Domain;
using MyHotel.ViewModel.LevelRoom;

namespace MyHotel.Services.Mapper
{
    public class LevelRoomProfile : Profile
    {
        public LevelRoomProfile()
        {
            CreateMap<LevelRoom, LevelRoomViewModel>().ReverseMap();
        }
    }
}
