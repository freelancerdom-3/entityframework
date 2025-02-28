using HMSAPI.Model.TblShift;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.TblShift
{
    public interface ITblShift
    {


        bool AddTimehift(TblShiftModel Shift);
        List<TblShiftModel> GetAll();



        bool deleteshift(int id);

        TblShiftModel getbyShitid(int id);
        bool updateShift(int id);
    }
}
