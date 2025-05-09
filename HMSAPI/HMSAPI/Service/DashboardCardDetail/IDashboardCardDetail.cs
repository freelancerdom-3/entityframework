using HMSAPI.Model.GenericModel;

namespace HMSAPI.Service.DashboardCardDetail
{
    public interface IDashboardCardDetail
    {
        Task<APIResponseModel> GetAllCardDetails();
        Task<APIResponseModel> GetPatientTableDetails();
        Task<APIResponseModel> GetFeedbackCardDetails();
    }
}
