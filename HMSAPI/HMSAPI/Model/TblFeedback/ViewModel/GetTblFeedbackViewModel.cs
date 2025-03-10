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

    }
}
