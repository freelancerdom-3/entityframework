using HMSAPI.Model.GenericModel;
using HMSAPI.Service.TblHospitalType;
using HMSAPI.Service.TblMenuPermission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblMenuPermission
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblMenuPermissionController : ControllerBase
    {
        private readonly ITblMenuPermission _servicetblMenuPermission;

        public TblMenuPermissionController(ITblMenuPermission tblmenupermission)
        {
            _servicetblMenuPermission = tblmenupermission;
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _servicetblMenuPermission.GetAll(searchBy);
        }
    }
}
