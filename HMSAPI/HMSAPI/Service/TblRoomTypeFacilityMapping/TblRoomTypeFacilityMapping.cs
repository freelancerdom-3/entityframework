using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRoomTypeFacilityMapping;
using HMSAPI.Model.TblRoomTypeFacilityMapping.View_Model;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblRoomTypeFacilityMapping
{
    public class TblRoomTypeFacilityMapping : ITblRoomTypeFacilityMapping
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;

        public TblRoomTypeFacilityMapping(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;
        }
        private int UserId => Convert.ToInt32(_tokenData.UserID);

        public async Task<APIResponseModel> Add(TblRoomTypeFacilityMappingModel facilitymodel)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool DuplicateRoomTypeFacilityMapping = connection.TblRoomTypeFacilityMapping.Any(X => X.RoomTypeFacilityMappingID == facilitymodel.RoomTypeFacilityMappingID);

                    if (!DuplicateRoomTypeFacilityMapping)
                    {
                        facilitymodel.CreatedBy = UserId;
                        facilitymodel.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        facilitymodel.VersionNo = 1;
                        _ = await connection.TblRoomTypeFacilityMapping.AddAsync(facilitymodel);
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

        public async Task<APIResponseModel> Update(TblRoomTypeFacilityMappingModel facilitymodel)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblRoomTypeFacilityMappingModel? data = await connection.TblRoomTypeFacilityMapping.Where(x => x.RoomTypeFacilityMappingID == facilitymodel.RoomTypeFacilityMappingID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        facilitymodel.UpdatedBy = UserId;
                        facilitymodel.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                       // data.FacilityName = facilitymodel.FacilityName;
                        data.UpdatedBy = facilitymodel.UpdatedBy;
                        data.UpdatedOn = facilitymodel.UpdatedOn;
                        data.RoomTypeFacilityMappingID = facilitymodel.RoomTypeFacilityMappingID;
                        data.RoomID = facilitymodel.RoomID;
                        data.FacilityID = facilitymodel.FacilityID;
                        data.IsActive = data.IsActive;
                        connection.TblRoomTypeFacilityMapping.Update(data);
                        data.IncreamentVersion();
                        connection.SaveChanges();
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Data = true;
                        responseModel.Message = "Record Updated Successfully:";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "AllReady Add";
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
                    TblRoomTypeFacilityMappingModel? data = await connection.TblRoomTypeFacilityMapping
                   .Where(x => x.RoomTypeFacilityMappingID == id)
                   .FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.TblRoomTypeFacilityMapping.Remove(data);
                        connection.SaveChanges();
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



        public async Task<APIResponseModel> Deletebyroomid(HSMDBContext context, int id)
        {
            APIResponseModel responseModel = new();
            try
            {
               

                List<TblRoomTypeFacilityMappingModel> roomid = context.TblRoomTypeFacilityMapping.Where(x => x.RoomID == id).ToList();

                if (roomid != null)
                {
                    foreach (TblRoomTypeFacilityMappingModel room in roomid) 
                    {
                        context.TblRoomTypeFacilityMapping.Remove(room);
                    }
                    await _hsmDbContext.SaveChangesAsync();
                }

                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Deleted Successfully";
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException?.Message ?? ex.Message;
                responseModel.Data = null;
            }

            return responseModel;
        }


        public async Task<APIResponseModel> GetById(int id)
        {
            APIResponseModel responseModel = new();
            TblRoomTypeFacilityMappingModel data = new TblRoomTypeFacilityMappingModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    data = await connection.TblRoomTypeFacilityMapping.Where(x => x.RoomTypeFacilityMappingID == id).FirstAsync();

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


        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            List<GetTblRoomTypeFacilityMapping> lsttblRoomTypeFacilityMappings = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lsttblRoomTypeFacilityMappings = await connection.gettblroomtypefacilitymapping.FromSqlRaw($@"
    SELECT 
        tblmapping.RoomTypeFacilityMappingID,
        trt.RoomType AS RoomType,
        tf.FacilityName AS FacilityName,
        tu.FullName AS CreatedBy,
        tuu.FullName AS UpdatedBy,
        tblmapping.CreatedOn,
        tblmapping.UpdatedOn,
        tblmapping.IsActive,
        tblmapping.VersionNo
    FROM TblRoomTypeFacilityMapping tblmapping
    INNER JOIN TblRoom troom ON troom.RoomID = tblmapping.RoomID
    INNER JOIN TblRoomType trt ON troom.RoomTypeID = trt.RoomTypeId
    INNER JOIN TblFacility tf ON tf.FacilityID = tblmapping.FacilityID
    LEFT JOIN TblUser tu ON tu.UserId = tblmapping.CreatedBy
    LEFT JOIN TblUser tuu ON tuu.UserId = tblmapping.UpdatedBy
    WHERE tu.FullName LIKE '%{searchBy}%'").ToListAsync();

                    responseModel.Data = lsttblRoomTypeFacilityMappings;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Successfully";
                }
                if (lsttblRoomTypeFacilityMappings != null)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get All Recode Successfull";
                    responseModel.Data = lsttblRoomTypeFacilityMappings;

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
