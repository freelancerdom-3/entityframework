using HMSAPI.Model.GenericModel;
using HMSAPI.Service.DashboardCardDetail;
using HMSAPI.Service.TblUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.DashboardCardDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardCardDetailController : ControllerBase
    {
        private readonly IDashboardCardDetail _serviceDashboardCardDetail;
        private readonly ITblUser _serviceTblUser;
        public DashboardCardDetailController(IDashboardCardDetail serviceDashboardCardDetail, ITblUser tblUser)
        {
            _serviceDashboardCardDetail = serviceDashboardCardDetail;
            _serviceTblUser = tblUser;
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> getAllDashboardCardDetails()
        {
            return await _serviceDashboardCardDetail.GetAllCardDetails();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAllforcount()
        {
            return await _serviceTblUser.GetAllforcount();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetFeedbackCardDetails()
        {
            return await _serviceDashboardCardDetail.GetFeedbackCardDetails();
        }

    }
}
