using HMSAPI.Model.GenericModel;
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
    public class GetTblRoom : ListViewModel
    {
        [Key]
        public int RoomID { get; set; }
        
        public string? RoomType { get; set; }
       
        public int RoomNumber { get; set; }
        
    }
}
