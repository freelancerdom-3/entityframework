using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblEmployeeshiftMapping
{
    public class TblEmployeeshiftMappingModel : SecurityModel
    {
        [Key]
      public int  EmployeeshiftMappingId  { get; set; }
        public DateTime? EmployeeshiftMappingStartingDate { get; set; }

        public DateTime? EmployeeshiftMappingEndingDate { get; set; }

        public int UserId { get; set; }

        public int ShiftId { get; set; }
    }
}
