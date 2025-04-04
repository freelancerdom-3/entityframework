using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblEmployeeDepartmentMapping;
using HMSAPI.Service.TblEmployeeDepartmentMapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblEmployeeDepartmentMapping
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblEmployeeDepartmentMappingController : ControllerBase
    {

        private readonly ITblEmployeeDepartmentMapping _serviceTblEmployeeDepartmentMapping;

        public TblEmployeeDepartmentMappingController(ITblEmployeeDepartmentMapping TblEmployeedepartmentmapping)
        {
            _serviceTblEmployeeDepartmentMapping = TblEmployeedepartmentmapping;

        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblEmployeeDepartmentMappingModel DeptModel)
        {
            return await _serviceTblEmployeeDepartmentMapping.Add(DeptModel);
        }
        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblEmployeeDepartmentMappingModel DeptModel)
        {
            return await _serviceTblEmployeeDepartmentMapping.Update(DeptModel);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _serviceTblEmployeeDepartmentMapping.Delete(id);
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblEmployeeDepartmentMapping.GetAll(searchBy);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int id)
        {
            return await _serviceTblEmployeeDepartmentMapping.GetByID(id);
        }
        [HttpDelete("[action]")]
        public async Task<APIResponseModel> DeleteByID(int id)
        {
            return await _serviceTblEmployeeDepartmentMapping.DeleteByID(id);
        }
    }
}
