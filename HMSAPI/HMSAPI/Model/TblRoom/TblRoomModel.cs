using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblRoom
{
    public class TblRoomModel : SecurityModel
    {
        [Key]
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeID { get; set; }
    }
}
