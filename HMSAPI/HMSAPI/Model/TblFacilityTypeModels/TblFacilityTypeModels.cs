using HMSAPI.Model.GenericModel;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblFacilityTypes
{
    public class TblFacilityTypeModels : SecurityModel
    {
        [Key]
        public int FacilityTypeID { get; set; }
        public string? FacilityName { get; set; }
    }
    public class GetTblFacilityTypeModels : ListViewModel
    {
        [Key]
        public int FacilityTypeID { get; set; }
        public string? FacilityName { get; set; }
    }
}