using MyHotel.Infrastructure;
using MyHotel.ViewModel.BedRoom;
using System.Collections.Generic;

namespace MyHotel.Services.Interfaces
{
    public interface IBedRoomService: IServiceBase<BedRoomViewModel>
    {
       new IEnumerable<BedRoomListViewModel> GetAll();
    }
}
