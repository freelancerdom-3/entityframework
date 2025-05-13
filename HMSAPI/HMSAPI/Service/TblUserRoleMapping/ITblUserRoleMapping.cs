using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblUserRoleMapping;

namespace HMSAPI.Service.TblUserRoleMapping
{
    public interface ITblUserRoleMapping
    {
        Task<APIResponseModel> Add(TblUserRoleMappingModel model);
        Task<APIResponseModel> GetAll(string? searchBy = null);

    }
}
