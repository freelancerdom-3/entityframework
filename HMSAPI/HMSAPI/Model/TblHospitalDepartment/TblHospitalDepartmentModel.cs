using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblHospitalDepartment
{
    public class TblHospitalDepartmentModel
    {
        [Key]
        public int HospitalDepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
