using AutoMapper;
using MyHotel.Domain;
using MyHotel.ViewModel;
using MyHotel.ViewModel.Users;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Services.Mapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser,UserListViewModel>().ReverseMap();
        }
    }
}
