using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblDiseaseType;

namespace HMSAPI.Service.TblDiseaseType
{
    public interface ITblDiseaseType
    {
        Task<APIResponseModel> Add(TblDiseaseTypeModel diseasetypeModel);
        Task<APIResponseModel> Update(int id);
        Task<APIResponseModel> delete(TblDiseaseTypeModel diseasetypeModel);
        Task<APIResponseModel> deleteByID(int id);
        Task<APIResponseModel> GetTbl(int Id);
        Task<APIResponseModel> GetAll(String? searchby = null);  
    }
}
