using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblMenuRoleMapping
{
    public class TblMenuRoleMapping : SecurityModel
    {
        [Key]
        public int MenuRoleMappingID { get; set; }
        public int RoleID { get; set; }
        public int MenuID { get; set; }
        public bool IsEdit { get; set; }
        public bool IsAdd { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; } 
    }
}

