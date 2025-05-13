using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblUser;
using HMSAPI.Model.TblUserRoleMapping;
using HMSAPI.Service.TblUser;
using HMSAPI.Service.TblUserRoleMapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblUserRoleMapping
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblUserRoleMappingController : ControllerBase
    {
        private readonly ITblUserRoleMapping _serviceTblUserRoleMapping;
        public TblUserRoleMappingController(ITblUserRoleMapping TblUserRoleMapping)
        {
            _serviceTblUserRoleMapping = TblUserRoleMapping;
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblUserRoleMapping.GetAll(searchBy);
        }


        [HttpPut("[action]")]
        public async Task<APIResponseModel> Add([FromBody]TblUserRoleMappingModel model)
        {
            return await _serviceTblUserRoleMapping.Add(model);
        }
    }
    }



