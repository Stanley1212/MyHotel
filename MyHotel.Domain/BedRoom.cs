using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotel.Domain
{
    public class BedRoom:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BedRoomID { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int LevelID { get; set; }
        public LevelRoom Level { get; set; }
        public int TypeRoomID { get; set; }
        public TypeRoom TypeRoom { get; set; }
        public string Status { get; set; } = "DISPONIBLE";
    }
}
