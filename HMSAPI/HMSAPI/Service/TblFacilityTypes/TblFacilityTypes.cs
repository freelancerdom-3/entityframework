using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFacilityTypes;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblFacilityTypes
{
    public class TblFacilityTypes : ITblFacilityTypes
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;

        public TblFacilityTypes(HSMDBContext hSMDBContext, ITokenData tokenData)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokenData;
        }
        private int UserId => Convert.ToInt32(_tokenData.UserID);

        public async Task<APIResponseModel> Add(TblFacilityTypeModels tblFacilityType)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicatefacility = connection.TblFacilityTypes
                        .Any(x => x.FacilityName.ToLower() == tblFacilityType.FacilityName.ToLower());
                    if (!duplicatefacility)
                    {
                       
                        //_ = await connection.TblFacilityTypes.AddAsync(tblFacilityType);
                        tblFacilityType.CreatedBy = UserId;
                        tblFacilityType.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        tblFacilityType.VersionNo = 1;
                        connection.TblFacilityTypes.Add(tblFacilityType);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Data = false;
                        responseModel.Message = "Duplicate Name Not Found";
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




        public async Task<APIResponseModel> Update(TblFacilityTypeModels tblFacilityType)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblFacilityTypeModels? data = await connection.TblFacilityTypes.Where(x => x.FacilityTypeID == tblFacilityType.FacilityTypeID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        tblFacilityType.UpdatedBy = UserId;
                        tblFacilityType.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        data.FacilityName = tblFacilityType.FacilityName;
                        data.UpdatedBy = tblFacilityType.UpdatedBy;
                        data.UpdatedOn = tblFacilityType.UpdatedOn;
                        data.IsActive = data.IsActive;
                        data.IncreamentVersion();
                        connection.TblFacilityTypes.Update(data);
                        connection.SaveChanges();
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Facility Successfully:";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Facility AllReady Add";
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

        public async Task<APIResponseModel> Delete(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblFacilityTypeModels? data = await connection.TblFacilityTypes.Where(x => x.FacilityTypeID == id).FirstOrDefaultAsync();
                    if (data != null)
                    {

                        data.IsActive= false;
                        connection.TblFacilityTypes.Update(data);
                        connection.SaveChanges();
                        responseModel.Data= true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete SuccessFully:";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "FacilityType Not Found";
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



        public async Task<APIResponseModel> GetByID(int id)
        {
            APIResponseModel responseModel = new();
            TblFacilityTypeModels data = new TblFacilityTypeModels();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    data = await connection.TblFacilityTypes.Where(x => x.FacilityTypeID == id && x.IsActive == true).FirstAsync();

                    if (data != null)
                    {
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Get Show Record SuccessFully";
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

        public async Task<APIResponseModel> GetAll(string? searchby = null)
        {
            APIResponseModel responseModel = new();
            List<GetTblFacilityTypeModels> lstFacility = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstFacility = connection.gettblfacilitytypemodels.FromSqlRaw($@"
                    SELECT tu.FullName AS CreatedBy, uu.FullName AS UpdatedBy, tr.FacilityTypeID, 
                  tr.FacilityName,tr.CreatedOn,tr.UpdatedOn, tr.IsActive,tr.VersionNo
                FROM TblFacilityType tr INNER JOIN TblUser tu ON tu.UserId = tr.CreatedBy 
                      left JOIN TblUser uu ON uu.UserId = tr.UpdatedBy where tr.IsActive = 1 and tu.fullName LIKE  '%{searchby}%'").ToList();

                    //lstFacility = string.IsNullOrEmpty(searchby) ? await connection.TblFacilityTypes.ToListAsync() :
                    //    await connection.TblFacilityTypes.Where(x => x.FacilityName.ToLower() == searchby.ToLower()).ToListAsync();

                }
                    if (lstFacility != null)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get All Recode Successfull";
                    responseModel.Data = lstFacility;

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
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
    }
}