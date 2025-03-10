using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Model.TblFacility;

namespace HMSAPI.Service.TblFacility
{
    public interface ITblFacility
    {
        Task<APIResponseModel> Add(TblFacilityModel tblFacility);
        Task<APIResponseModel> Update(TblFacilityModel tblFacility);
        Task<APIResponseModel> Delete(int Id);
        Task<APIResponseModel> GetTbl(int Id);
        Task<APIResponseModel> GetAll(String? searchBy = null);
    }
}
