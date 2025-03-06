using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblShift;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.TblShift
{
    public interface ITblShift
    {


        Task<APIResponseModel> Add(TblShiftModel Shift);
        Task<APIResponseModel> GetAll(string? searchBy = null);



        Task<APIResponseModel> Delete(int id);

        Task<APIResponseModel> GetById(int id);
        Task<APIResponseModel> Update(int id);
    }
}
