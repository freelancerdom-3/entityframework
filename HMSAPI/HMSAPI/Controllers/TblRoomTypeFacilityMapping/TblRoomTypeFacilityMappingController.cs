using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRoomTypeFacilityMapping;
using HMSAPI.Service.TblRoomTypeFacilityMapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblRoomTypeFacilityMapping
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblRoomTypeFacilityMappingController : ControllerBase
    {
        private readonly ITblRoomTypeFacilityMapping _servicetblroomfacilitymapping;

        public TblRoomTypeFacilityMappingController(ITblRoomTypeFacilityMapping TblRoomTypeFacilityMapping)
        {
            _servicetblroomfacilitymapping = TblRoomTypeFacilityMapping;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblRoomTypeFacilityMappingModel facilitymodel)
        {
            return await _servicetblroomfacilitymapping.Add(facilitymodel);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetById(int id)
        {
            return await _servicetblroomfacilitymapping.GetById(id);
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblRoomTypeFacilityMappingModel facilitymodel)
        {
            return await _servicetblroomfacilitymapping.Update(facilitymodel);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _servicetblroomfacilitymapping.Delete(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _servicetblroomfacilitymapping.GetAll(searchBy);
        }
    }
}

