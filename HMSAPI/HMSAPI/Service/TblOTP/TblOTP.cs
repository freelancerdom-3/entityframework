using System.Net;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblOTP;
using static System.Net.WebRequestMethods;

namespace HMSAPI.Service.TblOTP
{
    public class TblOTP : ITblOTP
    {
        private readonly HSMDBContext _hsmDbContext;

        public TblOTP(HSMDBContext hsmDBContext)
        {
            _hsmDbContext = hsmDBContext;
        }





        public async Task<APIResponseModel> GenerateOtp(int userId)
        {
            APIResponseModel responseModel = new();

            try
            {
                    
                using (var connection = _hsmDbContext)
                {
                    Random random = new ();

                    string otpCode = random.Next(100, 100000).ToString();


                    DateTime expiryTime = DateTime.Now.AddMinutes(3);


                  TblOTPModel otpModel = new TblOTPModel

                    {
                      Code = otpCode,
                      Expiry_time = expiryTime,
                      IsUse = false,
                      CreatedBy = userId
                    };

                     connection.tblotpmodel.Add(otpModel);
                     connection.SaveChanges();

                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "OTP generated successfully";
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }

            return responseModel;
        }


    }
}
