using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblEmpyloeeDepartmentMapping.ViewModel
{
    public class GetTblEmployeeDepartmentmappingViewModel
    {
        [Key]
        public int EmployeeDepartmentMappingId { get; set; }

        public string? FullName { get; set; }

        public string? DepartmentName { get; set; }
    }


    public class TblEmployeeDepartment : ListViewModel
    {
        [Key]
        public int EmployeeDepartmentMappingId { get; set; }

        public string? FullName { get; set; }

        public string? DepartmentName { get; set; }
    }
}
