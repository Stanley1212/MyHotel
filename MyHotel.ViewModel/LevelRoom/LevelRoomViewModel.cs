using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.ViewModel.LevelRoom
{
    public class LevelRoomViewModel
    {
        [Required]
        public int LevelID { get; set; }

        [Required]
        [Display(Name ="Piso")]
        public string Name { get; set; }
    }
}
