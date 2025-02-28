using HMSAPI.EFContext;
using HMSAPI.Model.TblModel;

namespace HMSAPI.Service.TblRole
{
    public class TblRole : ITblRole
        
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblRole(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }
        public bool AddRole(TblRoleModel roleModel)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                bool duplicateRoleName = connection.TblRoles.Any(x => x.RoleName.ToLower() == roleModel.RoleName.ToLower());
                if (!duplicateRoleName)
                {
                    _ = connection.TblRoles.Add(roleModel);
                    connection.SaveChanges();
                    result = true;
                }
                else 
                { 
                    result=false;
                }
                return result;
            }
        }
        public bool delete(int id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                TblRoleModel? data = connection.TblRoles.Where(x => x.RoleId == id).FirstOrDefault();
                if (data != null)
                {
                    connection.TblRoles.Remove(data);
                    connection.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;

                }
                return result;
            }
        }

        public List<TblRoleModel> GetAll(string? searchBy = null)
        {
            List<TblRoleModel> lstRolles = new();
            using (var connection = _hsmDbContext)
            {
                lstRolles = string.IsNullOrEmpty(searchBy) ? connection.TblRoles.ToList() : connection.TblRoles.Where(x => x.RoleName.ToLower() == searchBy.ToLower()).ToList();
            }
            return lstRolles;

        }

        public TblRoleModel Getone(int id)
        {

            using (var connection = _hsmDbContext)
            {
                TblRoleModel? data = connection.TblRoles.
                 Where(x => x.RoleId == id).FirstOrDefault();
                return data;
            }


        }

        public bool Update(int id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {

                TblRoleModel? data = connection.TblRoles.Where(x => x.RoleId == id).FirstOrDefault();

                if (data != null)
                {
                    data.RoleName = "vishal";
                    connection.TblRoles.Update(data);
                    connection.SaveChanges();
                    result = true;


                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
