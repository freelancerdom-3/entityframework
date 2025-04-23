using HMSAPI.Model.GenericModel;

namespace HMSAPI.Service.TblMenuPermission
{
    public interface ITblMenuPermission
    {
        Task<APIResponseModel> GetAll(string? searchBy = null);

    }
}
