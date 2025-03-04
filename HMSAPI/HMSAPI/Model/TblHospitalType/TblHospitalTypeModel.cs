using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblHospitalType
{
    public class TblHospitalTypeModel
    {
        [Key]
        public int HospitalTypeID { get; set; }
        public string? HospitalType { get; set; }
    }
}
