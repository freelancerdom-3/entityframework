using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.RoomTypeModel
{
    public class TblRoomTypeModel
    {
        [Key]
        public int RoomTypeId { get; set; }
        public string? RoomType { get; set; }
     
    }
}
