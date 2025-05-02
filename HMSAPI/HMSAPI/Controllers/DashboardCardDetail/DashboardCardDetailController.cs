using HMSAPI.Model.GenericModel;
using HMSAPI.Service.DashboardCardDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.DashboardCardDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardCardDetailController : ControllerBase
    {
        private readonly IDashboardCardDetail _serviceDashboardCardDetail;
        public DashboardCardDetailController(IDashboardCardDetail serviceDashboardCardDetail)
        {
            _serviceDashboardCardDetail = serviceDashboardCardDetail;
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> getAllDashboardCardDetails()
        {
            return await _serviceDashboardCardDetail.GetAllCardDetails();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetFeedbackCardDetails()
        {
            return await _serviceDashboardCardDetail.GetFeedbackCardDetails();
        }

    }
}
