using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRoom;
using HMSAPI.Model.TblRoomLocation;

namespace HMSAPI.Service.TblRoomLocations
{
    public interface ITblRoomLocations
    {
        Task<APIResponseModel> Add(TblRoomLocationModel tblRoomLocation);
        Task<APIResponseModel> Update(int id);
        Task<APIResponseModel> Delete(int id);
        Task<APIResponseModel> GetAll(string? searchBy = null);
        Task<APIResponseModel> GetByID(int id);

    }
}
