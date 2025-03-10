using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblRoom.View_Model
{
    public class GetTblRoomModel
    {
        [Key]
        public int RoomID { get; set; }
        public int RoomTypeID { get; set; }
        public string? FacilityName { get; set; }
    }
}
