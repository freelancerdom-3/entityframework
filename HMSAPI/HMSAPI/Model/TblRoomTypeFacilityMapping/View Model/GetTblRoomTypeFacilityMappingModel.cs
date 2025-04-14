using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblRoomTypeFacilityMapping.View_Model
{
    public class GetTblRoomTypeFacilityMappingModel
    {
        [Key]
        public int RoomTypeFacilityMappingID { get; set; }

        public string? FacilityName { get; set; }
        public string? RoomType { get; set; }
        public int RoomNumber { get; set; }
    }
    public class GetTblRoomTypeFacilityMapping : ListViewModel
    {
        [Key]
        public int RoomTypeFacilityMappingID { get; set; }
        public string? FacilityName { get; set; }
        public string? RoomType { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

}
