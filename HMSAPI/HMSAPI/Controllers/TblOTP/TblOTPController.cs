using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblOTP;
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
        public async Task<APIResponseModel> GenerateOtp([FromBody] GenerateOtpRequest request)
        {
            return await _serviceOTP.GenerateOtp(request.UserId, request.Email);
        }
        [HttpPost("[action]")]
        public async Task<APIResponseModel> VerifyOtp([FromBody] OtpVerificationModel model)
        {
            return await _serviceOTP.VerifyOtp(model.userId, model.otpCode);
        }


    }
}
