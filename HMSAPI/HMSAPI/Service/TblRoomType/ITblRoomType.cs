using HMSAPI.Model.GenericModel;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.RoomType
{
    public interface ITblRoomType
    {
        Task<APIResponseModel> GetAllRoomType(string? searchBy = null);
        Task<APIResponseModel> deleteRoomTypeByID(int id);
        Task<APIResponseModel> AddRoomType(TblRoomTypeModel TblRoomType);

        Task<APIResponseModel> GetByID(int id);
        Task<APIResponseModel> UpdateRoomType(int id);
    }
}
