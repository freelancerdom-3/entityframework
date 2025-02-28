using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblModel
{
    public class TblRoleModel
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
