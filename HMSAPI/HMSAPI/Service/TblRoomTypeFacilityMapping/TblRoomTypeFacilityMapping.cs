using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFacilityTypes;
using HMSAPI.Model.TblMedicineDiseaseMapping;
using HMSAPI.Model.TblRoomTypeFacilityMapping;
using HMSAPI.Model.TblRoomTypeFacilityMapping.View_Model;
using HMSAPI.Model.TblUser;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblRoomTypeFacilityMapping
{
    public class TblRoomTypeFacilityMapping : ITblRoomTypeFacilityMapping
    {
        private readonly HSMDBContext _hsmDbContext;

        public TblRoomTypeFacilityMapping(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

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
                    TblRoomTypeFacilityMappingModel? Data = await connection.TblRoomTypeFacilityMapping
                        .Where(X => X.RoomTypeFacilityMappingID == facilitymodel.RoomTypeFacilityMappingID).FirstOrDefaultAsync();
                    if (Data != null)
                    {
                        Data.RoomTypeFacilityMappingID = facilitymodel.RoomTypeFacilityMappingID;
                        Data.UpdateBy = Data.UpdateBy;
                        Data.UpdateOn = Data.UpdateOn;
                        Data.IsActive = Data.IsActive;
                        Data.IncreamentVersion();
                        connection.Update(Data);
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
            List<GetTblRoomTypeFacilityMappingModel> lsttblRoomTypeFacilityMappings = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lsttblRoomTypeFacilityMappings = await connection.GetTblRoomTypeFacilityMappingModel.FromSqlRaw($@"
select TblRoomTypeFacilityMapping.RoomTypeFacilityMappingID , TblRoom.RoomNumber , TblFacility.FacilityName,TblRoomType.RoomType  from TblRoomTypeFacilityMapping
                    inner join TblRoom  on TblRoom.RoomID = TblRoomTypeFacilityMapping.RoomId
                    inner join TblFacility on tblfacility.FacilityName = tblfacility.FacilityName
					inner join TblRoomType on TblRoomType.RoomType = TblRoomType.RoomType
                    where FacilityName
                    like '%{searchBy}%'").ToListAsync();
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
