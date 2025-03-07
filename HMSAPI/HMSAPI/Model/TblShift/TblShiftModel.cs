using System.ComponentModel.DataAnnotations;


namespace HMSAPI.Model.TblShift
{
    public class TblShiftModel
    {



        [Key]
        public int ShiftId { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }
        public string? Shiftname { get; set; }

    }
}
