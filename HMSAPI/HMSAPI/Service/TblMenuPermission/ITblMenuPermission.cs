using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMenuRoleMapping;

namespace HMSAPI.Service.TblMenuPermission
{
    public interface ITblMenuPermission
    {
        Task<APIResponseModel> GetAll(int? roleId = null, string? searchBy = null);

        Task<APIResponseModel> Add(List<TblMenuRoleMapping> newMappings);

    }
}
