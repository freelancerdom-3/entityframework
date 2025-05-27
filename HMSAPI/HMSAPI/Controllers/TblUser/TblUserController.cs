using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblUser;
using HMSAPI.Service.ProfileImage;
using HMSAPI.Service.TblUser;
using HMSAPI.Service.TokenData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblUser
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblUserController : ControllerBase
    {
        private readonly ITblUser _serviceTblUser;
        private readonly IProfileImageService _profileImageService;
        private readonly ITokenData _tokenData;
        public TblUserController(ITblUser tblUser, IProfileImageService profileImageService, ITokenData tokenData)
        {
            _serviceTblUser = tblUser;
            _profileImageService = profileImageService;
            _tokenData = tokenData;
        }


        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<APIResponseModel> ValidateCredential(string email, string password)
        {
            return await _serviceTblUser.ValidateCredential(email, password);
        }



        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblUser.GetAll(searchBy);
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> SignupUser(TblUserModel userModel)
        {
            return await _serviceTblUser.SignupUser(userModel);
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<APIResponseModel> ForgetPassword(string email)
        {
            return await _serviceTblUser.ForgetPassword(email);        
        }
        
        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblUserModel model)
        {
            return await _serviceTblUser.Add(model);
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblUserModel model)
        {
            return await _serviceTblUser.Update(model);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {   
            return await _serviceTblUser.Delete(id);
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> UploadProfileImage(IFormFile file)
        {

            return await _profileImageService.UploadProfileImage((int)_tokenData.UserID, file);

        }

        [HttpGet("[action]")]
        
        public async Task<APIResponseModel> GetProfileImage()
        {
            return await _profileImageService.GetProfileImage((int)_tokenData.UserID);
        }

        [HttpDelete("[action]")]
      
        public async Task<APIResponseModel> DeleteProfileImage()
        {
            return await _profileImageService.DeleteProfileImage((int)_tokenData.UserID);
        }

    }
}
