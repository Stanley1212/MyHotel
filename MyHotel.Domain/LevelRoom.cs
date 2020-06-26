using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotel.Domain
{
    public class LevelRoom : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelID { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
