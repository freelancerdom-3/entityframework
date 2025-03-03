using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.RoomTypeModel
{
    public class RoomTYpeModel
    {
        [Key]
        public int RoomId { get; set; }
        public string? RoomType { get; set; }
     
    }
}
