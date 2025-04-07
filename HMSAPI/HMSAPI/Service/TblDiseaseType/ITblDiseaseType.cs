using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblDiseaseType;

namespace HMSAPI.Service.TblDiseaseType
{
    public interface ITblDiseaseType
    {
        Task<APIResponseModel> Add(TblDiseaseTypeModel diseasetypeModel);
        Task<APIResponseModel> Update(int id);
        Task<APIResponseModel> deleteByID(int id);
        Task<APIResponseModel> GetByID(int Id);
        Task<APIResponseModel> GetAll(String? searchby = null);  
    }
}
