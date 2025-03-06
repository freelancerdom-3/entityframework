using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblPateintDoctormapping;
using HMSAPI.Service.TblPateintDoctormapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblPateintDoctormapping
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPateintDoctormappingController : ControllerBase
    {
        private readonly ITblPateintDoctormapping _servicetblPateintDoctormapping;

        public TblPateintDoctormappingController(ITblPateintDoctormapping tblPateintDoctormapping)
        {
            _servicetblPateintDoctormapping = tblPateintDoctormapping;
        }


        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblPateintDoctormappingModel DeptModel)
        {
            return await _servicetblPateintDoctormapping.Add(DeptModel);
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblPateintDoctormappingModel departmentModel)
        {
            return await _servicetblPateintDoctormapping.Update(departmentModel);
        }
        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _servicetblPateintDoctormapping.Delete(id);
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int id)
        {
            return await _servicetblPateintDoctormapping.GetByID(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _servicetblPateintDoctormapping.GetAll(searchBy);
        }
    }
}
