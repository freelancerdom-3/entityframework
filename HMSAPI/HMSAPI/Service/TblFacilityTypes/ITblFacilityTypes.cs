using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFacilityTypes;

namespace HMSAPI.Service.TblFacilityTypes
{
    public interface ITblFacilityTypes
    {
        Task<APIResponseModel> Add(TblFacilityTypeModels tblFacilityType);
        Task<APIResponseModel> Delete(int id);
        Task<APIResponseModel> Update(TblFacilityTypeModels tblFacilityType);
        Task<APIResponseModel> GetByID(int id);
        Task<APIResponseModel> GetAll(string? searchby = null);
    }
}