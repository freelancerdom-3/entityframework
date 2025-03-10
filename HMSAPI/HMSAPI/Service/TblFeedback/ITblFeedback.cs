using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFeedback;

namespace HMSAPI.Service.TblFeedback
{
    public interface ITblFeedback
    {

        Task<APIResponseModel> Add(TblFeedbackModel Feedbackmodel);

        Task<APIResponseModel> Update(TblFeedbackModel Feedbackmodel);

        Task<APIResponseModel> GetById(int id);

        //Task<APIResponseModel> GetAll(string? searchBy = null);
        Task<APIResponseModel> Delete(int id);
    }
}
