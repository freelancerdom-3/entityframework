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
        public async Task<APIResponseModel> GetAllRoomType(string? searchBy = null)
        {
            return await _serviceRoomType.GetAllRoomType(searchBy);
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> AddRoomTyp(TblRoomTypeModel roomTypeModel)
        {
            return await _serviceRoomType.AddRoomType(roomTypeModel);
          
        }



        [HttpPatch("[action]")]
        public async Task<APIResponseModel> UpdateRoomType(int id)
        {
            return await _serviceRoomType.UpdateRoomType(id);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> deleteRoomTypeByID(int id)
        {
            return await _serviceRoomType.deleteRoomTypeByID(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetById(int id)
        {
            return await _serviceRoomType.GetByID(id);
        }
    }
}
