using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Domain
{
    public class TypeRoom: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeRoomID { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
