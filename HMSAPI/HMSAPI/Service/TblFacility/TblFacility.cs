using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFacility;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblFacility
{
    public class TblFacility : ITblFacility
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;

        public TblFacility(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;
        }

        private int UserID => Convert.ToInt32(_tokenData.UserID);

        public async Task<APIResponseModel> Add(TblFacilityModel tblFacility)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicateName = connection.TblFacility
                    .Any(x => x.FacilityName.ToLower() == tblFacility.FacilityName.ToLower());

                    if (!duplicateName)
                    {
                        tblFacility.CreatedBy = UserID;
                        tblFacility.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        tblFacility.VersionNo = 1;
                        tblFacility.IsActive = true;
                        _ = await connection.TblFacility.AddAsync(tblFacility);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate Name Found";
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

        public async Task<APIResponseModel> Delete(int Id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblFacilityModel? data = await connection.TblFacility.Where(x => x.FacilityID == Id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        
                        data.IsActive = false;
                        connection.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID Not Found";
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

        
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();

            // if (_tokenData.IsPermission((int)Enums.Roles.Patient, "IsView"))
            List<GetTblFacilityModel> lstfacility = new();

            if (true)
            {
                try
                {

                    using (var connection = _hsmDbContext)
                    {
                        lstfacility = connection.gettblfacilitymodel.FromSqlRaw($@"
                                SELECT 
                                f.FacilityID,
                                f.FacilityName,
                                ft.FacilityName AS FacilityType,
                                cu.FullName AS CreatedBy,
                                f.CreatedOn,
                                uu.FullName AS UpdatedBy,
                                f.UpdatedOn,
                                f.IsActive,
                                f.VersionNo
                                FROM TblFacility f
                                LEFT JOIN TblFacilityType ft ON f.FacilityTypeID = ft.FacilityTypeID
                                LEFT JOIN TblUser cu ON f.CreatedBy = cu.UserId
                                LEFT JOIN TblUser uu ON f.UpdatedBy = uu.UserId where f.IsActive = 1  AND f.FacilityName
                                like '%{searchBy}%'").ToList();
                        responseModel.Data = lstfacility;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = null;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = HttpStatusCode.InternalServerError;
                    responseModel.Message = ex.InnerException.Message;
                    responseModel.Data = null;
                }
            }
            else
            {
                responseModel.Message = "you dont have permission";
            }

            return responseModel;
        }
    
        public async Task<APIResponseModel> GetTbl(int Id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblFacilityModel data = await connection.TblFacility.Where(x => x.FacilityID == Id && x.IsActive == true).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = data.FacilityName;
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID Not Found";
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

        public async Task<APIResponseModel> Update(TblFacilityModel tblFacility)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblFacilityModel? data = await connection.TblFacility.Where(x => x.FacilityID == tblFacility.FacilityID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        tblFacility.UpdatedBy = UserID;
                        data.FacilityName = tblFacility.FacilityName;
                        data.FacilityTypeID = tblFacility.FacilityTypeID;
                        data.UpdatedBy = tblFacility.UpdatedBy;
                        data.UpdatedOn = tblFacility.UpdatedOn;
                        //data.IsActive = tblFacility.IsActive;
                        data.IncreamentVersion();
                        connection.TblFacility.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate Name Found";
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
    }
}
