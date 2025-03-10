using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFacility;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Service.TblFacility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblFacility
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblFacilityController : ControllerBase
    {
        private readonly ITblFacility _servicetblfacility;
        public TblFacilityController(ITblFacility tblFacility)
        {
             _servicetblfacility = tblFacility;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblFacilityModel tblFacility)
        {
            return await _servicetblfacility.Add(tblFacility);
        }

        [HttpPatch("[action]")]
        public async Task<APIResponseModel> Update(TblFacilityModel tblFacility)
        {
            return await _servicetblfacility.Update(tblFacility);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int ID)
        {
            return await _servicetblfacility.Delete(ID);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetTbl(int id)
        {
            return await _servicetblfacility.GetTbl(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _servicetblfacility.GetAll(searchBy);
        }
    }
}
