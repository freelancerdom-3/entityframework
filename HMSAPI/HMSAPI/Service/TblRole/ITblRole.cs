using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRole;

namespace HMSAPI.Service.TblRole
{
    public interface ITblRole
    {

        //Task<APIResponseModel>
        Task<APIResponseModel> Add(TblRoleModel roleModel);

        Task<APIResponseModel> Update(int ObjId);

        Task<APIResponseModel> delete(int id);

        Task<APIResponseModel> GetById (int id);

        Task<APIResponseModel> GetAll(string? searchBy = null);
    }
}
