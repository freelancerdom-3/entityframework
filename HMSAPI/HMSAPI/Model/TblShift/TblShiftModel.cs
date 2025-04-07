using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;


namespace HMSAPI.Model.TblShift
{
    public class TblShiftModel : SecurityModel
    {



        [Key]
        public int ShiftId { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public string? Shiftname { get; set; }

    }
    public class GetTblShiftViewModel : ListViewModel
    {
        [Key]
        public int ShiftId { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public string? Shiftname { get; set; }
    }
}
