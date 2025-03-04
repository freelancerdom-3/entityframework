using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
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
        [HttpGet("AuthenticateUser")]
        public IActionResult ValidateCredential(string email, string password)
        {
            return Ok(_serviceTblUser.validateCredential(email, password));
        }


        //public IActionResult ValidateCredential1(string email, string password)
        //{
        //    return Ok(_serviceTblUser.validateCredential(email, password));
        //}

        [HttpGet("[action]")]
        public IActionResult validateCredentialWithData(string email, string password)
        {
            return Ok(_serviceTblUser.validateCredentialWithData(email, password));
        }

        [HttpGet("[action]")]
        public IActionResult GetAll(string? searchBy = null)
        {
            return Ok(_serviceTblUser.GetAll(searchBy));
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> SignupUser(TblUserModel userModel)
        {
            return await _serviceTblUser.SignupUser(userModel);
        }


        [HttpGet("[action]")]
        public IActionResult ForgetPassword(string email)
        {
            return Ok(_serviceTblUser.ForgetPassword(email));
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> AddRoleId(int userId)
        {
            return await _serviceTblUser.AddRoleId(userId);
        }
    }
}
