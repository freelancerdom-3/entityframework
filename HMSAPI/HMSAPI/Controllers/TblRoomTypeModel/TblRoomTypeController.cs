using HMSAPI.Model.GenericModel;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblUser;
using HMSAPI.Service.RoomType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.RoomType
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblRoomTypeController : ControllerBase
    {
        private readonly ITblRoomType _serviceRoomType;
        public TblRoomTypeController(ITblRoomType serviceRoomType)
        {
            _serviceRoomType = serviceRoomType;
        }


        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceRoomType.GetAll(searchBy);
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblRoomTypeModel roomTypeModel)
        {
            return await _serviceRoomType.Add(roomTypeModel);
          
        }



        [HttpPatch("[action]")]
        public async Task<APIResponseModel> Update(int id)
        {
            return await _serviceRoomType.Update(id);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> delete(int id)
        {
            return await _serviceRoomType.delete(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetById(int id)
        {
            return await _serviceRoomType.GetByID(id);
        }
    }
}
