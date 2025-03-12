using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblPatient.ViewModel;
using HMSAPI.Model.TblUser;
using HMSAPI.Service.TblUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblUserController : ControllerBase
    {
        private readonly ITblUser _serviceTblUser;
        public TblUserController(ITblUser tblUser)
        {
            _serviceTblUser = tblUser;
        }


        [HttpGet("[action]")]
        
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

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Update(TblUserModel model)
        {
            return await _serviceTblUser.Update(model);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {   
            return await _serviceTblUser.Delete(id);
        }
        
    }
}
