using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblBill;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.TblBill
{
    public interface ITblBill
    {
        Task<APIResponseModel> GetAll(string? searchBy = null);
        Task<APIResponseModel> GetByID(int id);
        Task<APIResponseModel> Add(TblBillModel bill);
        Task<APIResponseModel> Update(int id, TblBillModel bill);
        Task<APIResponseModel> Delete(int id);
    }
}
