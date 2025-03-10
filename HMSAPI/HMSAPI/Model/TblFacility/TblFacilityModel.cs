using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblFacility
{
    public class TblFacilityModel
    {
        [Key]
        public int FacilityID { get; set; }
        public string? FacilityName { get; set; }
        public int FacilityTypeID { get; set; }
    }
}
