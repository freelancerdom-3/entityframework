using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineType;
using HMSAPI.Service.TblMedicineDetails;
using HMSAPI.Service.TblMedicineDiseaseMapping;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.Service.TblMedicineType
{
    public class TblMedicineType : ITblMedicineType
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITblMedicineDetails _TblMedicineDetails;
        private readonly ITblMedicineDiseaseMapping _TblMedicineDiseaseMapping;
        private readonly ITokenData _tokenData;
        public TblMedicineType(HSMDBContext hsmDbContext,ITblMedicineDetails tblMedicineDetails,ITblMedicineDiseaseMapping TblMedicineDiseaseMapping, ITokenData tokendata)
        {
            _hsmDbContext = hsmDbContext;
            _TblMedicineDetails= tblMedicineDetails;
            _TblMedicineDiseaseMapping= TblMedicineDiseaseMapping;
            _tokenData = tokendata;
        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);

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
                        medicineModel.CreatedBy = UserId;
                        medicineModel.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); 
                        medicineModel.VersionNo = 1;
                        
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
                        data.IsActive = false;
                        connection.TblMedicineTypes.Update(data);
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

        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new APIResponseModel();
            List<GetTblMedicineTypeViewModel> lstmedicine = new List<GetTblMedicineTypeViewModel>();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstmedicine = connection.GetTblMedicineTypeViewModels.FromSqlRaw($@"
                    select tu.FullName AS CreatedBy, uu.FullName AS UpdatedBy, tr.MedicineTypeID, 
                    tr.TypeName,tr.CreatedOn,tr.UpdatedOn, tr.IsActive,tr.VersionNo
                    FROM TblMedicineType tr INNER JOIN TblUser tu ON tu.UserId = tr.CreatedBy  
                    left JOIN TblUser uu ON uu.UserId = tr.UpdatedBy
					where tr.IsActive = 1
                    and tu.fullName LIKE  '%{searchBy}%'").ToList();
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
                    TblMedicineTypeModel? data = await connection.TblMedicineTypes
                        .Where(X => X.MedicineTypeID == id && X.IsActive == true).FirstOrDefaultAsync();
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
                        data.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); 
                        data.UpdatedBy = UserId;
                        data.TypeName = model.TypeName;
                        data.IncreamentVersion();
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
