using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblMenuRoleMapping
{
    public class TblMenuRoleMapping
    {
        [Key]
        public int MenuRoleMapping { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        // The property name must match exactly. Check for any typos or casing issues.
        public int IsAdd { get; set; }
        public int IsEdit { get; set; }
        public int IsDelete { get; set; }

        public int IsView {  get; set; }    
    }
}
