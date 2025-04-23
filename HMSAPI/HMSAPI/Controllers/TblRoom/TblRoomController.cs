using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRoom;
using HMSAPI.Service.TblRoom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblRoom
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblRoomController : ControllerBase
    {
        private readonly ITblRoom _serviceRoom;
        public TblRoomController(ITblRoom serviceRoom)
        {
            _serviceRoom = serviceRoom;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblRoomModel tblRoom)
        {
            return await _serviceRoom.Add(tblRoom);

        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceRoom.GetAll(searchBy);
        }


        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblRoomModel tblRoom)
        {
            return await _serviceRoom.Update(tblRoom);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _serviceRoom.Delete(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int id)
        {
            return await _serviceRoom.GetByID(id);
        }
    }
}
