using MyHotel.ViewModel.LevelRoom;
using MyHotel.ViewModel.TypeRoom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.ViewModel.BedRoom
{
    public class BedRoomViewModel
    {
        public int BedRoomID { get; set; }
        [Display(Name = "Habitación"),Required]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Display(Name = "Precio"), Required]
        public decimal Price { get; set; }
        [Display(Name = "Piso")]
        public int LevelID { get; set; }
        public IEnumerable<LevelRoomViewModel> Levels { get; set; }
        [Display(Name = "Tipo de Habitación")]
        public int TypeRoomID { get; set; }
        public IEnumerable<TypeRoomViewModel> TypeRooms { get; set; }
    }
}
