using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFacilityTypes;
using HMSAPI.Service.TblFacilityTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblFacilityTypes
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblFacilityTypesController : ControllerBase
    {
        private readonly ITblFacilityTypes _serviceTblFacilityType;

        public TblFacilityTypesController(ITblFacilityTypes tblFacilityTypes)
        {
            _serviceTblFacilityType = tblFacilityTypes;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblFacilityTypeModels tblFacilityType)
        {
            return await _serviceTblFacilityType.Add(tblFacilityType);
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblFacilityTypeModels tblFacilityType)
        {
            return await _serviceTblFacilityType.Update(tblFacilityType);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _serviceTblFacilityType.Delete(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int id)
        {
            return await _serviceTblFacilityType.GetByID(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblFacilityType.GetAll(searchBy);
        }
    }
}
