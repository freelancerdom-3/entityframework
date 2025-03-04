using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblEmpyloeeDepartmentMapping.ViewModel
{
    public class GetTblEmployeeDepartmentmappingViewModel
    {
        [Key]
        public int EmployeeDepartmentMappingId { get; set; }

        public string? FullName { get; set; }

        public string? DepartmentName { get; set; }
    }
}
