using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblEmployeeshiftMapping
{
    public class TblEmployeeshiftMappingModel
    {
        [Key]
      public int  EmployeeshiftMappingId  { get; set; }
        public DateTime? EmployeeshiftMappingStartingDate { get; set; }

        public DateTime? EmployeeshiftMappingEndingData { get; set; }

        public int UserId { get; set; }

        public int ShiftId { get; set; }
    }
}
