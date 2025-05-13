using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMSAPI.Model.TblUserRoleMapping
{
    public class TblUserRoleMappingModel : SecurityModel
    {
        [Key]
        public int TblUserRoleMappingID { get; set; }

        public int UserId { get; set; }

    
        public int RoleId { get; set; }


        [NotMapped] //no column in sql
        public List<int>? RoleIds { get; set; }
    }

    public class TblUserRoleMappingViewModel
    {


        [Key]
        public string FullName { get; set; }

       // public DateTime? CreatedOn { get; set; }

        public string RoleNames { get; set; }

        

    }
}
