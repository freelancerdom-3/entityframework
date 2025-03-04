using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblUser
{
    public class TblUserModel
    {
        [Key]
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? MobileNumber { get; set; }

        public int RoleId { get; set; }
    }
}
