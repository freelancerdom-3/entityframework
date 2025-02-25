using HMSAPI.Model.TblHospitalDep;
using HMSAPI.Model.TblUser;
using HMSAPI.Service.TblHospitalDept;
using HMSAPI.Service.TblUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblHospitalDept
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblHospitalDeptController : ControllerBase
    {
        private readonly ITblHospitalDept _serviceTblHosDep;
        public TblHospitalDeptController(ITblHospitalDept TblHosDept)
        {
            _serviceTblHosDep = TblHosDept;
        }
        [HttpPost("[action]")]
        public IActionResult AddDepartment(TblHospitalDeptModel DeptModel)
        {
            return Ok(_serviceTblHosDep.AddDepartment(DeptModel));
        }

        [HttpPut("[action]")]
        public IActionResult UpdateDepartment(int id)
        {
            return Ok(_serviceTblHosDep.UpdateDepartment(id));
        }
        [HttpDelete("[action]")]
        public IActionResult DeleteDepartment(int id)
        {
            return Ok(_serviceTblHosDep.DeleteDepartment(id));
        }
        [HttpGet("[action]")]
        public IActionResult GetDepartmentByID(int id)
        {
            return Ok(_serviceTblHosDep.GetDepartmentByID(id));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllDepartment(string? searchBy = null)
        {
            return Ok(_serviceTblHosDep.GetAllDepartment(searchBy));
        }
    }
}
