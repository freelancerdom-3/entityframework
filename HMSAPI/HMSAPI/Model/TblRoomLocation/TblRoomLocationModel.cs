using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblRoomLocation
{
    public class TblRoomLocationModel
    {
        [Key]
        public int RoomLocationID { get; set; }
        public int Floornumber { get; set; }
        public int RoomID { get; set; }
       
    }
}
