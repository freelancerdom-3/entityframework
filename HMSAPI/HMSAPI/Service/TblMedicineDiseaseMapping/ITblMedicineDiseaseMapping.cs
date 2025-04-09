using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineDiseaseMapping;

namespace HMSAPI.Service.TblMedicineDiseaseMapping
{
    public interface ITblMedicineDiseaseMapping
    {
        Task<APIResponseModel> Add(TblMedicineDiseaseMappingModel model);
        Task<APIResponseModel> Update(TblMedicineDiseaseMappingModel MedicineDiseaseMapping);
        Task<APIResponseModel> GetAll(string? searchby = null);
        Task<APIResponseModel> GetByID(int ID);
        Task<APIResponseModel> DeleteByID(int ID);
        Task<APIResponseModel> DeletebyMedicineTypeID(HSMDBContext connection, int id);

        Task<APIResponseModel> DeletebyDiseaseTypeID(HSMDBContext connection, int id);
    }
}
