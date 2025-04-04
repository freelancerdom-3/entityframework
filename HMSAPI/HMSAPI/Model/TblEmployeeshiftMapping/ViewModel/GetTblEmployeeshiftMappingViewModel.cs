using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblEmployeeshiftMapping.ViewModel
{
    public class GetTblEmployeeshiftMappingViewModel
    {
        [Key]
        public int EmployeeshiftMappingId { get; set; }
      
       public string? FullName { get; set; }
        public string? Shiftname { get; set; }



        public DateTime? EmployeeshiftMappingStartingDate { get; set; }

        public DateTime? EmployeeshiftMappingEndingDate { get; set; }
    }
}
