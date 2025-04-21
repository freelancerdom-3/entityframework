using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Service.TblMedicineDiseaseMapping;
using HMSAPI.Service.TblTreatmentDetails;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace HMSAPI.Service.TblDiseaseType
{
    public class TblDiseaseType : ITblDiseaseType
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;
        private readonly ITblMedicineDiseaseMapping _medicineDiseaseMapping;
        private readonly ITblTreatmentDetails _treatmentDetails;
        public TblDiseaseType(HSMDBContext hSMDBContext,ITblMedicineDiseaseMapping medicineDiseaseMapping,ITblTreatmentDetails treatmentDetails, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;
           _medicineDiseaseMapping = medicineDiseaseMapping;
            _treatmentDetails=treatmentDetails;
        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);

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
                        tblDiseaseType.CreatedBy=UserId;
                        tblDiseaseType.IsActive = true;
                        tblDiseaseType.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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

        public async Task<APIResponseModel> Update(TblDiseaseTypeModel model)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblDiseaseTypeModel? data = await connection.TblDiseaseType.Where(x => x.DieseaseTypeID == model.DieseaseTypeID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        data.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); ;
                        data.UpdatedBy = UserId;
                        data.IsActive = model.IsActive;
                        data.DieseaseName = model.DieseaseName;
                        data.DieseaseTypeID = model.DieseaseTypeID;
                       
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

                       // _medicineDiseaseMapping?.DeletebyDiseaseTypeID(connection, id);
                       // _treatmentDetails?.DeletebyDiseaseTypeID(connection, id);
                        data.IsActive = false;
                        connection.TblDiseaseType.Update(data);
                        connection.SaveChanges();
                        responseModel.Data=true;
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
                    data = await connection.TblDiseaseType.Where(x => x.DieseaseTypeID == id && x.IsActive==true).FirstAsync();

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
            List<getdiseasetypeviewmodel> lstDisease = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstDisease = connection.getdiseasetypeviewmodels.FromSqlRaw($@"
                   SELECT tu.FullName AS CreatedBy, uu.FullName AS UpdatedBy, tr.DieseaseTypeID, 
   tr.DieseaseName,tr.CreatedOn,tr.UpdatedOn, tr.IsActive,tr.VersionNo
     FROM TblDiseaseType tr INNER JOIN TblUser tu ON tu.UserId = tr.CreatedBy  
      left JOIN TblUser uu ON uu.UserId = tr.UpdatedBy
     where tr.IsActive = 1 and tu.fullName LIKE  '%{searchby}%'").ToList();

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
