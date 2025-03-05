using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblRoom
{
    public class TblRoomModel
    {
        [Key]
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeID { get; set; }
    }
}
