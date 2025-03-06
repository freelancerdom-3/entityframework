using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblRole
{
    public class TblRoleModel
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}