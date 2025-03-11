using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblEmployeeDepartmentMapping
{
    public class TblEmployeeDepartmentMappingModel : SecurityModel
    {

        [Key]
        public int EmployeeDepartmentMappingId { get; set; }

        public int UserId { get; set; }

        public int HospitalDepartmentId { get; set; }




    }
}
