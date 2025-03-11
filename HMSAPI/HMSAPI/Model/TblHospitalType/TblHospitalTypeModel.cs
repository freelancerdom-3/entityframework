using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblHospitalType
{
    public class TblHospitalTypeModel : SecurityModel
    {
        [Key]
        public int HospitalTypeID { get; set; }
        public string? HospitalType { get; set; }
    }
}
