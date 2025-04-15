using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblRoomTypeFacilityMapping
{
    public class TblRoomTypeFacilityMappingModel : SecurityModel
    {
        [Key]
        public int RoomTypeFacilityMappingID { get; set; }
        public int RoomID { get; set; }
        public int FacilityID { get; set; }
        //public string? FacilityName { get; set; }
    }
}
