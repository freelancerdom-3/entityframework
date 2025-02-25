using HMSAPI.EFContext;
using HMSAPI.Model.TblMedicineType;

namespace HMSAPI.Service.TblMedicineType
{
    public class TblMedicineType : ITblMedicineType
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblMedicineType(HSMDBContext hsmDbContext)
        {
            _hsmDbContext = hsmDbContext;
        }

        

        public bool AddMedicine(TblMedicineTypeModel medicineModel)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                bool duplicateName = connection.TblMedicineTypes
                .Any(X => X.TypeName.ToLower() == medicineModel.TypeName.ToLower());

                if (!duplicateName)
                {
                    _ = connection.TblMedicineTypes.Add(medicineModel);
                    connection.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;

        }

        public bool DeleteByID(int Id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                TblMedicineTypeModel? data = connection.TblMedicineTypes.Where(X => X.MedicineID == Id).FirstOrDefault();
                if (data != null)
                {
                    connection.TblMedicineTypes.Remove(data);
                    connection.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }

        }

        public List<TblMedicineTypeModel> GetAll()
        {
            List<TblMedicineTypeModel> lstmedicine = new List<TblMedicineTypeModel>();
            using (var connection = _hsmDbContext)
            {
                lstmedicine = connection.TblMedicineTypes.ToList();
            }
            return lstmedicine;
                
        }

        public TblMedicineTypeModel? GetOnlyOneByID(int id)
        {
            using (var connection = _hsmDbContext)
            {
                TblMedicineTypeModel? data = connection.TblMedicineTypes
                    .Where(X => X.MedicineID == id).FirstOrDefault();
                return data;
            }
            
        }

        public bool UpdateByID(int Id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                TblMedicineTypeModel? data = connection.TblMedicineTypes.Where(X => X.MedicineID == Id).FirstOrDefault();
                if (data != null)
                {
                    data.TypeName = "No Medicine";
                    connection.Update(data);
                    connection.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
        }
    }
}
