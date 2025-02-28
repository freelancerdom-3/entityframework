using HMSAPI.Model.TblModel;

namespace HMSAPI.Service.TblRole
{
    public interface ITblRole
    {
        bool AddRole(TblRoleModel roleModel);





       //bool validateCredential(string RoleName);
        bool Update(int id);

        bool delete(int id);

        TblRoleModel Getone(int id);

        List<TblRoleModel> GetAll(string? searchBy = null);
    }
}
