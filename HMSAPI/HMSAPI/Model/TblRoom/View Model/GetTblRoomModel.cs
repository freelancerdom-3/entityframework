using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblRoom.View_Model
{
    public class GetTblRoomModel
    {
        [Key]
        public int RoomID { get; set; }
       
        public string? RoomType { get; set; }
        public int RoomNumber { get; set; }
        
    }
}
