using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineType;

namespace HMSAPI.Service.TblMedicineType
{
    public interface ITblMedicineType
    {
        Task<APIResponseModel> Add(TblMedicineTypeModel medicineModel);

        Task<APIResponseModel> GetByID(int id);

        Task<APIResponseModel> GetAll(string? searchBy = null);

        Task<APIResponseModel> Update(TblMedicineTypeModel model);

        Task<APIResponseModel> Delete(int Id);

        
    }
}
