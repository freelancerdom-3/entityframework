using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblDiseaseType;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace HMSAPI.Service.TblDiseaseType
{
    public class TblDiseaseType : ITblDiseaseType
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblDiseaseType(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        // ADD DIEASES 

        public async Task<APIResponseModel> Add(TblDiseaseTypeModel tblDiseaseType)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool DuplicateDieases = connection.TblDiseaseType
                        .Any(x => x.DieseaseName.ToLower() == tblDiseaseType.DieseaseName.ToLower());
                    if (!DuplicateDieases)
                    {
                        tblDiseaseType.VersionNo = 1;
                        _ = await connection.TblDiseaseType.AddAsync(tblDiseaseType);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate Name Found:";
                        responseModel.Data = false;

                    }

                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> Update(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblDiseaseTypeModel? data = await connection.TblDiseaseType.Where(x => x.DieseaseTypeID == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        data.UpdatedOn = data.UpdatedOn;
                        data.UpdatedBy = data.UpdatedBy;
                        data.IsActive = data.IsActive;
                        data.IncreamentVersion();
                        connection.TblDiseaseType.Update(data);
                        connection.SaveChanges();
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Dieases Successfully:";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Dieases AllReady Add";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.BadRequest;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = false;
            }
            return responseModel;

        }

        //DELETEBYID
        public async Task<APIResponseModel> deleteByID(int id)

        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblDiseaseTypeModel? data = await connection.TblDiseaseType
                   .Where(x => x.DieseaseTypeID == id)
                   .FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.TblDiseaseType.Remove(data);
                        connection.SaveChanges();
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete SuccessFully:";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "DieasesName Is Not Found";
                        responseModel.Data = false;
                    }
                }

            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;

        }
        

        //GETTBL
        public async Task<APIResponseModel> GetByID(int id)
        {
            APIResponseModel responseModel = new();
            TblDiseaseTypeModel data = new TblDiseaseTypeModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    data = await connection.TblDiseaseType.Where(x => x.DieseaseTypeID == id).FirstAsync();

                    if (data != null)
                    {
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Get Shaw Record SuccessFully";
                        responseModel.Data = data;
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Does Not Match A Data";
                        responseModel.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        //GETALL
        public async Task<APIResponseModel> GetAll(string? searchby = null)
        {
            APIResponseModel responseModel = new();
            List<TblDiseaseTypeModel> lstDisease = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstDisease = string.IsNullOrEmpty(searchby) ? await connection.TblDiseaseType.ToListAsync() :
                        await connection.TblDiseaseType.Where(x => x.DieseaseName.ToLower() == searchby.ToLower()).ToListAsync();

                }
                if (lstDisease != null)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get All Recode Successfull";
                    responseModel.Data = lstDisease;

                }
                else
                {
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                    responseModel.Message = "Record Not Found";
                    responseModel.Data = null;
                }

            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex?.InnerException?.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
    }
}
