using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.ViewModel.BedRoom
{
    public class BedRoomListViewModel
    {
        public int BedRoomID { get; set; }

        [Display(Name = "Habitación")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Display(Name = "Precio")]
        public decimal Price { get; set; }
        [Display(Name = "Piso")]
        public string LevelName { get; set; }
        [Display(Name = "Tipo de Habitación")]
        public string TypeRoomName { get; set; }
        public int LevelID { get; set; }
        public string Status { get; set; } = "DISPONIBLE";
    }
}
