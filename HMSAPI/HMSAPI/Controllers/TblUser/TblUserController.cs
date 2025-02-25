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
        public IActionResult ValidateCredential(string email, string password) {
            return Ok(_serviceTblUser.validateCredential(email, password));
        }

       
        //public IActionResult ValidateCredential1(string email, string password)
        //{
        //    return Ok(_serviceTblUser.validateCredential(email, password));
        //}

        [HttpGet("[action]")]
        public IActionResult validateCredentialWithData(string email, string password) {
            return Ok(_serviceTblUser.validateCredentialWithData(email, password));
        }

        [HttpGet("[action]")]
        public IActionResult GetAll(string? searchBy = null)
        {
            return Ok(_serviceTblUser.GetAll(searchBy));
        }

        [HttpPost("[action]")]
        public IActionResult SignupUser(TblUserModel userModel)
        {
            return Ok(_serviceTblUser.SignupUser(userModel));
        }
        
        [HttpGet("[action]")]
        public IActionResult ForgetPassword(string email)
        {
            return Ok(_serviceTblUser.ForgetPassword(email));
        }
    }
}
