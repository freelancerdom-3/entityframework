using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblEmployeeshiftMapping;
using HMSAPI.Service.TblEmployeeshiftMapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblEmployeeshiftMapping
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblEmployeeshiftMappingController : ControllerBase
    {
        private readonly ITblEmployeeshiftMapping _serviceTblEmployeeshiftMapping;


        public TblEmployeeshiftMappingController(ITblEmployeeshiftMapping tblEmployeeshiftMapping)
        {
            _serviceTblEmployeeshiftMapping = tblEmployeeshiftMapping;
        }


        [HttpPost("[action]")]

        public async Task<APIResponseModel> Add([FromBody] TblEmployeeshiftMappingModel objModel)
        {
            return await _serviceTblEmployeeshiftMapping.Add(objModel);
        }


        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update([FromBody] TblEmployeeshiftMappingModel employeeshiftmapping)
        {
            return await _serviceTblEmployeeshiftMapping.Update(employeeshiftmapping);
        }



        [HttpDelete("[action]")]
        public async Task<APIResponseModel> delete(int id)
        {
            return await _serviceTblEmployeeshiftMapping.delete(id);
        }
        [HttpGet("[action]")]

        public async Task<APIResponseModel> GetById(int id)
        {
            return await _serviceTblEmployeeshiftMapping.GetById(id);
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblEmployeeshiftMapping.GetAll(searchBy);
        }
    }
}
