using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblRoomLocation.View_Model
{
    public class GetTblRoomLocationModel
    {
        [Key]
        public int RoomLocationID { get; set; }
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
    }
}
