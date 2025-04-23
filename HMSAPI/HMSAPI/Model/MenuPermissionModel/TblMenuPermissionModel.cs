using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.MenuPermissionModel
{
    public class TblMenuPermissionModel
    {
        [Key]
        public int MenuRoleMappingID { get; set; }
        public int RoleID { get; set; }
        public int MenuID { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

    }
}
