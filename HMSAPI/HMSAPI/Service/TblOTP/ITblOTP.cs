using HMSAPI.Model.GenericModel;

namespace HMSAPI.Service.TblOTP
{
    public interface ITblOTP
    {
        Task<APIResponseModel> GenerateOtp(int userId);
        Task<APIResponseModel> VerifyOtp(int userId, string  otpCode);
    }
}
