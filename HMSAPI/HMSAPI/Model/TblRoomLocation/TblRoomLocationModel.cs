using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblRoomLocation
{
    public class TblRoomLocationModel : SecurityModel
    {
        [Key]
        public int RoomLocationID { get; set; }
        public int Floornumber { get; set; }
        public int RoomID { get; set; }
       
    }
}
