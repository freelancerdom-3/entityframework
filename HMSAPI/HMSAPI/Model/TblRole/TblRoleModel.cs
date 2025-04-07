using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblRole
{
    public class TblRoleModel : SecurityModel
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
    public class GetTblRoleViewModel : ListViewModel
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

    }
}