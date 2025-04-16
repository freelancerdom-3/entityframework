using HMSAPI.Model.GenericModel;

namespace HMSAPI.Service.DashboardCardDetail
{
    public interface IDashboardCardDetail
    {
        Task<APIResponseModel> GetAllCardDetails();
    }
}
