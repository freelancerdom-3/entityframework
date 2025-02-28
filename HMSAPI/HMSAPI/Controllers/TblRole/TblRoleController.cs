using HMSAPI.Model.TblModel;
using HMSAPI.Service.TblRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblRole
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblRoleController : ControllerBase
    {
        private readonly ITblRole _serviceTblRole;

        public TblRoleController(ITblRole tblRole)
        {
            _serviceTblRole = tblRole;
        }

        [HttpPost("[action]")]

        public IActionResult AddRole(TblRoleModel roleModel)
        {
            return Ok(_serviceTblRole.AddRole(roleModel));
        }

        [HttpPatch("[action]")]
        public IActionResult Update(int id)
        {
            return Ok(_serviceTblRole.Update(id));
        }

        [HttpDelete("[action]")]

        public IActionResult delete(int id)
        {
            return Ok(_serviceTblRole.delete(id));
        }
        [HttpGet("[action]")]

        public IActionResult Getone(int id)
        {
            return Ok(_serviceTblRole.Getone(id));
        }

        [HttpGet("[action]")]
        public IActionResult GetAll(string? searchBy = null)
        {
            return Ok(_serviceTblRole.GetAll(searchBy));
        }
    }
}
