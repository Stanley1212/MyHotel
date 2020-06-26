using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.ViewModel.TypeRoom
{
    public class TypeRoomViewModel
    {
        public int TypeRoomID { get; set; }

        [Required]
        [Display(Name ="Tipo de habitacion")]
        public string Name { get; set; }
    }
}
