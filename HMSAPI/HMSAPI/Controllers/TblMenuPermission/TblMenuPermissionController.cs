using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMenuRoleMapping;
using HMSAPI.Service.TblMenuPermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblMenuPermission
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblMenuPermissionController : ControllerBase
    {
        private readonly ITblMenuPermission _servicetblMenuPermission;

        public TblMenuPermissionController(ITblMenuPermission tblmenupermission)
        {
            _servicetblMenuPermission = tblmenupermission;
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(int? roleId = null, string? searchBy = null)
        {
            return await _servicetblMenuPermission.GetAll(roleId, searchBy);
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(List<TblMenuRoleMapping> newMappings)
        {
            return await _servicetblMenuPermission.Add(newMappings);
        }
    }
}
