using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineDetails;

namespace HMSAPI.Service.TblMedicineDetails
{
    public interface ITblMedicineDetails
    {
        Task<APIResponseModel> Add(TblMedicineDetailsModel model);
        Task<APIResponseModel> Update(TblMedicineDetailsModel TblMedicineDetails);
        Task<APIResponseModel> Delete(int ID);
        Task<APIResponseModel> GetByID(int ID);
    }
}
