using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMenuRoleMapping;
using HMSAPI.Model.TblPateintDoctormapping;
using HMSAPI.Service.TblHospitalType;
using HMSAPI.Service.TblMenuPermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _servicetblMenuPermission.GetAll(searchBy);
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(List<TblMenuRoleMapping> newMappings)
        {
            return await _servicetblMenuPermission.Add(newMappings);
        }
    }
}
