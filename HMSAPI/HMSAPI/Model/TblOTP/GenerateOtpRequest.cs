using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblOTP
{
    public class GenerateOtpRequest
    {

        [Required]
        public int UserId { get; set; } 

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
