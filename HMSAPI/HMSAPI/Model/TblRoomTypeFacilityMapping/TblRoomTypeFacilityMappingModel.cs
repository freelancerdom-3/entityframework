using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblRoomTypeFacilityMapping
{
    public class TblRoomTypeFacilityMappingModel
    {
        [Key]
        public int RoomTypeFacilityMappingID { get; set; }
        public int RoomID { get; set; }
        public int FacilityID { get; set; }
    }
}
