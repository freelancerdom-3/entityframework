﻿using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRole;
using HMSAPI.Service.TblRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblRole
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblRoleController : ControllerBase
    {
        private readonly ITblRole _serviceTblRole;

        public TblRoleController(ITblRole tblRole)
        {
            _serviceTblRole = tblRole;
        }

        [HttpPost("[action]")]

        public async Task<APIResponseModel> Add(TblRoleModel roleModel)
        {
            return await (_serviceTblRole.Add(roleModel));
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblRoleModel roleModel)
        {
            return await (_serviceTblRole.Update(roleModel));
        }

        [HttpDelete("[action]")]

        public async Task<APIResponseModel> delete(int id)
        {
            return await (_serviceTblRole.delete(id));
        }
        [HttpGet("[action]")]

        public async Task<APIResponseModel> GetById(int id)
        {
            return await (_serviceTblRole.GetById(id));
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await   (_serviceTblRole.GetAll(searchBy));          




        }
    }
}
