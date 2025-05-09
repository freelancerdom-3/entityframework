using HMSAPI.Model.GenericModel;
using HMSAPI.Service.DashboardCardDetail;
using HMSAPI.Service.TblBill;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ITblBill _serviceTblBill;
        private readonly ITblUser _serviceTblUser;
        public DashboardCardDetailController(IDashboardCardDetail serviceDashboardCardDetail, ITblUser tblUser, ITblBill tblBill)
        {
            _serviceDashboardCardDetail = serviceDashboardCardDetail;
            _serviceTblBill = tblBill;
            _serviceTblUser = tblUser;
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> getAllDashboardCardDetails()
        {
            return await _serviceDashboardCardDetail.GetAllCardDetails();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetPatientTableDetails()
        {
            return await _serviceDashboardCardDetail.GetPatientTableDetails();
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


        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetTotalEarningsByDate()
        {
            return await _serviceTblBill.GetTotalEarningsByDate();
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetTotalEarningsWeek(string? searchBy = null)
        {
            return await _serviceTblBill.GetTotalEarningsWeek(searchBy);
        }


    }
}
