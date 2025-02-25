using HMSAPI.Model.TblMedicineType;

namespace HMSAPI.Service.TblMedicineType
{
    public interface ITblMedicineType
    {
        bool AddMedicine(TblMedicineTypeModel medicineModel);

        TblMedicineTypeModel? GetOnlyOneByID (int id);

        List<TblMedicineTypeModel> GetAll();

        bool UpdateByID(int Id);

        bool DeleteByID(int Id);
    }
}
