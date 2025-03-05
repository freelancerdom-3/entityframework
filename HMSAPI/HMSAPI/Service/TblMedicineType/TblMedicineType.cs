using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineType;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.Service.TblMedicineType
{
    public class TblMedicineType : ITblMedicineType
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblMedicineType(HSMDBContext hsmDbContext)
        {
            _hsmDbContext = hsmDbContext;
        }

        

        public async Task<APIResponseModel> Add(TblMedicineTypeModel medicineModel)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                bool result = false;
                using (var connection = _hsmDbContext)
                {
                    bool duplicateName = connection.TblMedicineTypes
                    .Any(X => X.TypeName.ToLower() == medicineModel.TypeName.ToLower());

                    if (!duplicateName)
                    {
                        _ =await connection.TblMedicineTypes.AddAsync(medicineModel);
                        connection.SaveChanges();
                        responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
                        responseModel.Data = true;
                    }
                    else
                    {
                        responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate found!";
                        responseModel.Data = false;
                    }
                }
            
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;

        }

        public async Task<APIResponseModel> Delete(int Id)
        {
            APIResponseModel responseModel = new();
            try
            {
                bool result = false;
                using (var connection = _hsmDbContext)
                {
                    TblMedicineTypeModel? data =await connection.TblMedicineTypes.Where(X => X.MedicineTypeID == Id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.TblMedicineTypes.Remove(data);
                        connection.SaveChanges();
                        responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                        responseModel.Message = "Deleted Successfully";
                        responseModel.Data = true;
                    }
                    else
                    {
                        responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        responseModel.Message = "Medicine ID not found!";
                        responseModel.Data = false;
                    }
                }   
                
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;

        }

        public async Task<APIResponseModel> GetAll()
        {
            APIResponseModel responseModel = new APIResponseModel();
            List<TblMedicineTypeModel> lstmedicine = new List<TblMedicineTypeModel>();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstmedicine = await connection.TblMedicineTypes.ToListAsync();
                    responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responseModel.Message = "Get All Record Successfully";
                    responseModel.Data = lstmedicine;
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
                
        }

        public async Task<APIResponseModel> GetByID(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblMedicineTypeModel? data =await connection.TblMedicineTypes
                        .Where(X => X.MedicineTypeID == id).FirstOrDefaultAsync();
                    responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responseModel.Message = "Get All Record Successfully";
                    responseModel.Data = data;
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;

        }

        public async Task<APIResponseModel> Update(TblMedicineTypeModel model)
        {
            APIResponseModel responseModel = new();
            try
            {
                bool result = false;
                using (var connection = _hsmDbContext)
                {
                    TblMedicineTypeModel? data = await connection.TblMedicineTypes
                        .Where(X => X.MedicineTypeID == model.MedicineTypeID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        data.TypeName = model.TypeName;
                        connection.Update(data);
                        connection.SaveChanges();
                        responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                        responseModel.Data = true;
                        responseModel.Message = "Record Updated Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        responseModel.Data = false;
                        responseModel.Message = "Not Updated";
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
    }
}
