using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineDiseaseMapping;
using HMSAPI.Model.TblMedicineDiseaseMapping.ViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.Service.TblMedicineDiseaseMapping
{
    public class TblMedicineDiseaseMapping : ITblMedicineDiseaseMapping
    {

        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;
        public TblMedicineDiseaseMapping(HSMDBContext hsmDbContext, ITokenData tokendata)
        {
            _hsmDbContext = hsmDbContext;
            _tokenData = tokendata;
        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        
        public async Task<APIResponseModel> Add(TblMedicineDiseaseMappingModel model)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool DuplicateDisease = connection.TblMedicineDiseaseMappings.Any(X => X.DieseaseTypeID == model.DieseaseTypeID);

                    if (!DuplicateDisease)
                    {
                        model.CreatedBy = UserId;
                        model.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        model.VersionNo = 1;
                        model.IsActive = true;
                        _ = await connection.TblMedicineDiseaseMappings.AddAsync(model);
                        connection.SaveChanges();
                        responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                        responseModel.Data = true;
                        responseModel.Message = "Record Inserted Sucessfully";

                    }
                    else
                    {
                        responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate Disease Found";
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

        public async Task<APIResponseModel> DeleteByID(int ID)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblMedicineDiseaseMappingModel? data = await connection.TblMedicineDiseaseMappings
                        .Where(x => x.MedicineDiseaseMappingID == ID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        data.IsActive = false;
                        connection.TblMedicineDiseaseMappings.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                        responseModel.Message = "Deleted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        responseModel.Message = "Delete Not successfully";
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



        public async Task<APIResponseModel> GetAll(string? searchby = null)
        {
            APIResponseModel responseModel = new();
            List<GetTblMedicineDiseaseMappingModel> lstmapping = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstmapping = await connection.gettblmedicinediseasemappingmodel.FromSqlRaw($@"
                        SELECT 
                        mdm.MedicineDiseaseMappingID,
                        dt.DieseaseName,
                        mt.TypeName,
                        createdBy.FullName AS CreatedBy,
                        updatedBy.FullName AS UpdatedBy,
	                    mdm.CreatedOn,mdm.UpdatedOn,mdm.IsActive,mdm.VersionNo
	                    FROM TblMedicineDiseaseMapping mdm
	                    LEFT JOIN TblDiseaseType dt ON mdm.DieseaseTypeID = dt.DieseaseTypeID
	                    LEFT JOIN TblMedicineType mt ON mdm.MedicineTypeID = mt.MedicineTypeID
	                    LEFT JOIN TblUser createdBy ON mdm.CreatedBy = createdBy.UserId
	                    LEFT JOIN TblUser updatedBy ON mdm.UpdatedBy = updatedBy.UserId
	                    where mdm.IsActive = 1 and dt.IsActive = 1 and mt.IsActive = 1
                        and  DieseaseName like '%{searchby}%'").ToListAsync();
                    responseModel.Data = lstmapping;
                    responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responseModel.Message = "GetAll Record Successfully";

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

        public async Task<APIResponseModel> GetByID(int ID)
        {
            APIResponseModel responseModel = new APIResponseModel();
            TblMedicineDiseaseMappingModel? data = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    data = await connection.TblMedicineDiseaseMappings.Where(X => X.MedicineDiseaseMappingID == ID && X.IsActive == true).FirstOrDefaultAsync();
                    responseModel.Data = data;
                    responseModel.StatusCode = System.Net.HttpStatusCode.OK;
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

        public async Task<APIResponseModel> Update(TblMedicineDiseaseMappingModel MedicineDiseaseMapping)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblMedicineDiseaseMappingModel? Data = await connection.TblMedicineDiseaseMappings
                        .Where(X => X.DieseaseTypeID == MedicineDiseaseMapping.DieseaseTypeID).FirstOrDefaultAsync();
                    if (Data != null)
                    {
                        MedicineDiseaseMapping.UpdatedBy = UserId;
                        MedicineDiseaseMapping.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        Data.MedicineDiseaseMappingID = MedicineDiseaseMapping.MedicineDiseaseMappingID;
                        Data.MedicineTypeID = MedicineDiseaseMapping.MedicineTypeID;
                        Data.DieseaseTypeID = MedicineDiseaseMapping.DieseaseTypeID;
                        Data.IsActive = Data.IsActive;
                        connection.Update(Data);
                        Data.IncreamentVersion();
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
