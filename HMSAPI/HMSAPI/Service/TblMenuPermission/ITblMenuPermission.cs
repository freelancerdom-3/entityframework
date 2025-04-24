using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMenuRoleMapping;

namespace HMSAPI.Service.TblMenuPermission
{
    public interface ITblMenuPermission
    {
        Task<APIResponseModel> GetAll(string? searchBy = null);

        Task<APIResponseModel> Add(List<TblMenuRoleMapping> newMappings);

    }
}
