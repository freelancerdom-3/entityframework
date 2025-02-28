using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblUser;
using HMSAPI.Service.RoomType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.RoomType
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomType _serviceRoomType;
        public RoomTypeController(IRoomType serviceRoomType)
        {
            _serviceRoomType = serviceRoomType;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(string? searchBy = null)
        {
            return Ok(_serviceRoomType.getAll(searchBy));
        }

        [HttpPost("[action]")]
        public IActionResult AddRoomTyp(RoomTYpeModel roomTYpeModel)
        {
            return Ok(_serviceRoomType.AddRoomTyp(roomTYpeModel));
        }



        [HttpPatch("[action]")]
        public IActionResult UpdateRoomTyp(int ID)
        {
            return Ok(_serviceRoomType.UpdateRoomTyp(ID));
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteRoomTyp(int ID)
        {
            return Ok(_serviceRoomType.DeleteRoomTyp(ID));
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            return Ok(_serviceRoomType.GetById(id));
        }
    }

 }
