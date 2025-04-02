using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineDiseaseMapping;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

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
    }
}
