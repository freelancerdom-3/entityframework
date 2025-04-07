using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.RoomType
{
    public interface ITblRoomType
    {
        Task<APIResponseModel> GetAll(string? searchBy = null);
        Task<APIResponseModel> delete(int id);
        Task<APIResponseModel> Add(TblRoomTypeModel TblRoomType);

        Task<APIResponseModel> GetByID(int id);
        Task<APIResponseModel> Update(TblRoomTypeModel id);
    }
}
