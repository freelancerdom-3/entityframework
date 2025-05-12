using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblFacility
{
    public class TblFacilityModel : SecurityModel
    {
        [Key]
        public int FacilityID { get; set; }
        public string? FacilityName { get; set; }
        public int FacilityTypeID { get; set; }
    }

    public class GetTblFacilityModel : ListViewModel
    {
        [Key]
        public int FacilityID { get; set; }
        public string? FacilityName { get; set; }
        public string? FacilityType { get; set; }
    }
}

