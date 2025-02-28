using HMSAPI.Model.TblHospitalTyp;
using HMSAPI.Service.TblHospitalTyp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblHospitalTyp
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblHospitalTypController : ControllerBase
    {
        private readonly ITblHospitalTyp _serviceTblHospitalTyp;

        public TblHospitalTypController(ITblHospitalTyp tblHospital)
        {
            _serviceTblHospitalTyp = tblHospital;
        }

        [HttpPost("[action]")]
        public IActionResult AddHospitalTyp(TblHospitalTypModel hospitalTypModel)
        {
            return Ok(_serviceTblHospitalTyp.AddHospitalTyp(hospitalTypModel));
        }



        [HttpPatch("[action]")]
        public IActionResult UpdateHospitalTyp(int ID)
        {
            return Ok(_serviceTblHospitalTyp.UpdateHospitalTyp(ID));
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteHospitalTyp(int ID)
        {
            return Ok(_serviceTblHospitalTyp.DeleteHospitalTyp(ID));
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            return Ok(_serviceTblHospitalTyp.GetById(id));
        }

        [HttpGet("[action]")]
        public IActionResult GetAll(string? searchBy = null)
        {
            return Ok(_serviceTblHospitalTyp.GetAll(searchBy));
        }
    }


}
