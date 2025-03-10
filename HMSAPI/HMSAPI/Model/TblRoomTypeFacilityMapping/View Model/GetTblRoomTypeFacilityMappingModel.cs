using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblRoomTypeFacilityMapping.View_Model
{
    public class GetTblRoomTypeFacilityMappingModel
    {
        [Key]
        public int RoomTypeFacilityMappingID { get; set; }

        public string? FacilityName { get; set; }
        public int RoomID { get; set; }
        public int FacilityID { get; set; }
    }
}
