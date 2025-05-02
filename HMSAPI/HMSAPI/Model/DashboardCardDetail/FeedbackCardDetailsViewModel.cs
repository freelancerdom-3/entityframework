using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.DashboardCardDetail
{
    public class FeedbackCardDetailsViewModel
    {
        [Key]
        public int FeedbackId { get; set; }

        public string? FullName { get; set; }

        public string? Comments { get; set; } 
    }
}
