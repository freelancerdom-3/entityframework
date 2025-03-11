using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblFeedback
{
    public class TblFeedbackModel : SecurityModel
    {
        [Key]
        public int FeedbackId { get; set; }
        public int PatientId { get; set; }
        public string? Comments { get; set; }
        public int Rating { get; set; }
        public string? Response { get; set; }
        public int TreatmentDetailsId { get; set; }
        public DateOnly? FeedbackDate { get; set; }

    }
}
