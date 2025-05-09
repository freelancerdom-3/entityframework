using System.Net;
using System.Net.NetworkInformation;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblOTP;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.Service.TblOTP
{
    public class TblOTP : ITblOTP
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly IConfiguration _configuration;

        public TblOTP(HSMDBContext hsmDbContext, IConfiguration configuration)
        {
            _hsmDbContext = hsmDbContext;
            _configuration = configuration;
        }




        public async Task<APIResponseModel> GenerateOtp(int userId)  
        {
            APIResponseModel responseModel = new();

            try
            {

                string otpLengthDecrypted = AESHelper.Decrypt(_configuration["Otpsettings:Otplength"]);
                string otpExpiryDecrypted = AESHelper.Decrypt(_configuration["Otpsettings:otpexpireduration"]);

                int otpLength = int.Parse(otpLengthDecrypted);
                int otpExpiry = int.Parse(otpExpiryDecrypted);

                int minValue = (int)Math.Pow(10, otpLength - 4);
                int maxValue = (int)Math.Pow(10, otpLength) - 1;



                var existingOtp = await _hsmDbContext.tblotpmodel.Where(x => x.CreatedBy == userId && x.IsUse == false).OrderByDescending(x => x.OtpID).FirstOrDefaultAsync();


                if (existingOtp != null && existingOtp.Expiry_time > DateTime.Now)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Existing OTP (valid)";
                    responseModel.Data = existingOtp;
                    return responseModel;
                }
                else
                {
                    using (var connection = _hsmDbContext)
                    {
                        Random random = new();

                        string otpCode = random.Next(minValue, maxValue).ToString();



                        DateTime expiryTime = DateTime.Now.AddMinutes(otpExpiry);


                        TblOTPModel otpModel = new TblOTPModel

                        {
                            Code = otpCode,
                            Expiry_time = expiryTime,
                            IsUse = false,
                            CreatedBy = userId
                        };

                        connection.tblotpmodel.Add(otpModel);
                        connection.SaveChanges();

                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "OTP generated successfully";
                    }
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



        public async Task<APIResponseModel> VerifyOtp([FromQuery] int userId, [FromQuery] string otpCode)
        {
            APIResponseModel responseModel = new();

            try
            {
                using (HSMDBContext connection = _hsmDbContext)
                {
                    TblOTPModel? latestOtp = await connection.tblotpmodel.Where(x => x.CreatedBy == userId && x.IsUse == false).OrderByDescending(x => x.Expiry_time).FirstOrDefaultAsync();



                    if (latestOtp?.Code == otpCode && DateTime.Now <= latestOtp.Expiry_time)
                    {

                        latestOtp.IsUse = true;
                        connection.tblotpmodel.Update(latestOtp);
                        
                        await connection.SaveChangesAsync();

                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "OTP verified successfully";
                    }
                    else
                    {

                        responseModel.Data = false;
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Invalid or expired OTP";
                    }

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


