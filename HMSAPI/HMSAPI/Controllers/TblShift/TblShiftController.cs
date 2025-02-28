using HMSAPI.Model.TblShift;
using HMSAPI.Service.TblShift;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblShift
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblShiftController : ControllerBase
    {

        private readonly ITblShift _serviceTblShift;

        public TblShiftController(ITblShift Shift)
        {

            _serviceTblShift = Shift;
        }


        //[HttpPost("[action]")]
        //public IActionResult SignupUser(TblUserModel userModel)
        //{
        //    return Ok(_serviceTblUser.SignupUser(userModel));
        //}



        [HttpPost("[action]")]
        public IActionResult AddTimehift(TblShiftModel TblShiftModel)
        {
            return Ok(_serviceTblShift.AddTimehift(TblShiftModel));
        }


        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_serviceTblShift.GetAll());
        }


        [HttpDelete("[action]")]
        public IActionResult DeleteShift(int id)
        {

            return Ok(_serviceTblShift.deleteshift(id));
        }

        [HttpPut("[action]")]
        public IActionResult updateShift(int id)
        {
            return Ok(_serviceTblShift.updateShift(id));
        }



        [HttpGet("[action]")]
        public IActionResult getbyShitid(int id)
        {
            return Ok(_serviceTblShift.getbyShitid(id));
        }



    }
}
