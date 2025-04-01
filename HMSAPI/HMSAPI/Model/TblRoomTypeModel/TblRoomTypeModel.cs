using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.RoomTypeModel
{
    public class TblRoomTypeModel : SecurityModel
    {
        [Key]
        public int RoomTypeId { get; set; }
        public string? RoomType { get; set; }
     
    }
    public class GetTblRoomTypeViewModel : ListViewModel
    {
        [Key]
        public int RoomTypeId { get; set; }
        public string? RoomType { get; set; }

    }
}
