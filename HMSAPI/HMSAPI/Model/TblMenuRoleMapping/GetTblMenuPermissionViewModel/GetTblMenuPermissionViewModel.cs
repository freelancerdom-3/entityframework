using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblMenuRoleMapping.GetTblMenuPermissionViewModel
{
    public class GetTblMenuPermissionViewModel
    {
        [Key]
        public int MenuRoleMappingID { get; set; }
       // public int RoleID { get; set; }
      
        //public int MenuID { get; set; }
        public bool IsEdit { get; set; }
        public bool IsAdd { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        //public string ParentMenuName { get; set; }
        public string? MenuName { get; set; }
        public string? RoleName { get; set; }
    }
}
