using HMSAPI.Model.GenericModel;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblRoom;

namespace HMSAPI.Service.TblRoom
{
    public interface ITblRoom
    {
        Task<APIResponseModel> Add(TblRoomModel tblRoom);
        Task<APIResponseModel> Update(int id);
        Task<APIResponseModel> Delete(int id);
        Task<APIResponseModel> GetAll();
         Task<APIResponseModel> GetByID(int id);
       
    }
}
