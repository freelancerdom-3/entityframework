using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.RoomType
{
    public interface IRoomType
    {
        List<RoomTYpeModel> getAll(string? searchBy = null);

        bool AddRoomTyp(RoomTYpeModel RoomTyp);

        bool UpdateRoomTyp(int id);

        bool DeleteRoomTyp(int id);

        RoomTYpeModel? GetById(int id);





    }
}
