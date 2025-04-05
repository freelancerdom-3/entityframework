using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFeedback;

namespace HMSAPI.Service.TblFeedback
{
    public interface ITblFeedback
    {

        Task<APIResponseModel> Add(TblFeedbackModel Feedbackmodel);
        Task<APIResponseModel> GetAll(string? searchBy = null);
        Task<APIResponseModel> Delete(int id);
        Task<APIResponseModel> Deletebyid(int id);
    }
}
