using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblFacilityTypes
{
    public class TblFacilityTypeModels
    {
        [Key]
        public int FacilityTypeID { get; set; }
        public string? FacilityName { get; set; }
    }
}