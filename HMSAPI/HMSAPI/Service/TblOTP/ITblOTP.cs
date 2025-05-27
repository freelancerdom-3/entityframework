using HMSAPI.Model.GenericModel;

namespace HMSAPI.Service.TblOTP
{
    public interface ITblOTP
    {
        Task<APIResponseModel> GenerateOtp(int userId, string email);
        Task<APIResponseModel> VerifyOtp(int userId, string  otpCode);
    }
}
