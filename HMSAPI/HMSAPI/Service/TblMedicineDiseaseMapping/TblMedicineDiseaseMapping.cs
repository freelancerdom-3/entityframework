using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineDetails;
using HMSAPI.Model.TblMedicineDiseaseMapping;
using HMSAPI.Model.TblMedicineDiseaseMapping.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblMedicineDiseaseMapping
{
    public class TblMedicineDiseaseMapping : ITblMedicineDiseaseMapping
    {

        private readonly HSMDBContext _hsmDbContext;
        public TblMedicineDiseaseMapping(HSMDBContext hsmDbContext)
        {
            _hsmDbContext = hsmDbContext;
        }

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
                        model.VersionNo = 1;
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
            List<GetTblMedicineDiseaseMappingViewModel> lstmapping = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstmapping = await connection.GetTblMedicineDiseaseMappingViewModels.FromSqlRaw($@"
                        select Tblmapping.MedicineDiseaseMappingID,dis.DieseaseName,tblmedi.TypeName
                        from TblMedicineDiseaseMapping Tblmapping
                        inner join TblDiseaseType dis on dis.DieseaseTypeID = Tblmapping.DieseaseTypeID  and dis.IsActive = 1
                        inner join TblMedicineType tblmedi on Tblmapping.MedicineTypeID = tblmedi.MedicineTypeID   and tblmedi.IsActive = 1 
                        where Tblmapping.IsActive = 1
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
                        Data.MedicineTypeID = MedicineDiseaseMapping.MedicineTypeID;
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
