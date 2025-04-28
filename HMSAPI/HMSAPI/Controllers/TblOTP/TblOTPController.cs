using HMSAPI.Model.GenericModel;
using HMSAPI.Service.TblOTP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblOTP
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblOTPController : ControllerBase
    {
        private readonly ITblOTP _serviceOTP;

        public TblOTPController(ITblOTP serviceOTP)
        {
            _serviceOTP = serviceOTP;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> GenerateOtp(int userId)
        {
            return await _serviceOTP.GenerateOtp(userId);
        }
        [HttpPost("[action]")]
        public async Task<APIResponseModel> VerifyOtp(int userId, string otpCode)
        {
            return await _serviceOTP.VerifyOtp(userId, otpCode);
        }


    }
}
