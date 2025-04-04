using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRoomLocation;
using HMSAPI.Service.TblRoomLocations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblRoomLocation
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblRoomLocationController : ControllerBase
    {
        private readonly ITblRoomLocations _serviceRoomLocation;

        public TblRoomLocationController(ITblRoomLocations serviceRoomLocation)
        {
            _serviceRoomLocation = serviceRoomLocation;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblRoomLocationModel tblRoomLocation)
        {
            return await _serviceRoomLocation.Add(tblRoomLocation);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceRoomLocation.GetAll(searchBy);
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(int id)
        {
            return await _serviceRoomLocation.Update(id);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _serviceRoomLocation.Delete(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int id)
        {
            return await _serviceRoomLocation.GetByID(id);
        }
    }
}

