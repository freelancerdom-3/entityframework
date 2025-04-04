using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblEmployeeshiftMapping;

namespace HMSAPI.Service.TblEmployeeshiftMapping
{
    public interface ITblEmployeeshiftMapping
    {
        Task<APIResponseModel> Add(TblEmployeeshiftMappingModel objModelID);

        Task<APIResponseModel> Update(TblEmployeeshiftMappingModel employeeshiftmapping);

        Task<APIResponseModel> delete(int id);


        Task<APIResponseModel> GetById(int id);


        Task<APIResponseModel> GetAll(string? searchBy = null);
        Task<APIResponseModel> DeleteByShiftId(HSMDBContext context, int id);

    }
}
