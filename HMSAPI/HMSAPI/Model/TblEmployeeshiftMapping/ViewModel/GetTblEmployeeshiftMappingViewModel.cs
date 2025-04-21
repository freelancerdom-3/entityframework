using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblEmployeeshiftMapping.ViewModel
{
    public class GetTblEmployeeshiftMappingViewModel : SecurityModel
    {
        [Key]
        public int EmployeeshiftMappingId { get; set; }
      
       public string? FullName { get; set; }
        public string? Shiftname { get; set; }


        public DateTime? EmployeeshiftMappingStartingDate { get; set; }

        public DateTime? EmployeeshiftMappingEndingDate { get; set; }
    }

    public class GetEmployeeMapping : ListViewModel
    {
        [Key]
        public int EmployeeshiftMappingId { get; set; }

        public string? FullName { get; set; }
        public string? Shiftname { get; set; }


        public DateTime? EmployeeshiftMappingStartingDate { get; set; }

        public DateTime? EmployeeshiftMappingEndingDate { get; set; }
        public int UserId { get; set; }

        public int ShiftId { get; set; }
    }
}
