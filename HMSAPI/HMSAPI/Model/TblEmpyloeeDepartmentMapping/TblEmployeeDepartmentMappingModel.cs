using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblEmployeeDepartmentMapping
{
    public class TblEmployeeDepartmentMappingModel
    {

        [Key]
        public int EmployeeDepartmentMappingId { get; set; }

        public int UserId { get; set; }

        public int HospitalDepartmentId { get; set; }




    }
}
