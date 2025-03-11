using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblHospitalDepartment
{
    public class TblHospitalDepartmentModel : SecurityModel
    {
        [Key]
        public int HospitalDepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
