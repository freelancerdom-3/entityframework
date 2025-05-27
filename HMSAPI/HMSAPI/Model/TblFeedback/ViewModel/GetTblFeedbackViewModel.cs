using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblFeedback.ViewModel
{
    public class GetTblFeedbackViewModel
    {
        [Key]
        public int FeedbackId { get; set; }
        public  string? FullName {  get; set; }
        public string? Comments { get; set; }
        public int  Rating  { get; set; }
        public DateOnly FeedbackDate {  get; set; }

        public int TreatmentDetailsId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public int? VersionNo { get; set; }

    }
}
