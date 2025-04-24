using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblOTP
{
    public class TblOTPModel
    {
        [Key]
        public int OtpID { get; set; }
        public string? Code { get; set; }
        public DateTime Expiry_time { get; set; }
        public bool IsUse { get; set; }
        public int? CreatedBy { get; set; }
    }
}
