using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblHospitalDep
{
    public class TblHospitalDeptModel
    {
        [Key]
        public int DeptId { get; set; }
        public string? Department { get; set; }
    }
}
