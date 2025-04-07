using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblMenuRoleMapping;
using HMSAPI.Service.RoomType;
using HMSAPI.Service.TblPatientAdmitionDetails;
using HMSAPI.Service.TblRoom;
using HMSAPI.Service.TblRoomLocations;
using HMSAPI.Service.TblRoomTypeFacilityMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSAPI.Service.TblRoomType
{
    public class TblRoomType : ITblRoomType
    {
        private readonly HSMDBContext _hsmDbContext;

        private readonly ITblRoomTypeFacilityMapping _tblRoomTypeFacilityMapping;
        private readonly ITblRoomLocations _tblRoomLocations;
        private readonly ITblRoom _tblRoom;
        private readonly ITblPatientAdmitionDetails _tblPatientAdmitionDetails;
        public TblRoomType(HSMDBContext hSMDBContext, ITblRoomTypeFacilityMapping RoomTypeFacilityMapping, ITblRoomLocations tblRoomLocations, ITblRoom tblRoom, ITblPatientAdmitionDetails tblPatientAdmitionDetails)
        {
            _hsmDbContext = hSMDBContext;
            _tblRoomTypeFacilityMapping = RoomTypeFacilityMapping;
            _tblRoomLocations = tblRoomLocations;
            _tblRoom = tblRoom;
            _tblPatientAdmitionDetails = tblPatientAdmitionDetails;

        }


        public async Task<APIResponseModel> Add(TblRoomTypeModel TblRoomTyp)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool DuplicateRoomType = connection.tblRoomTypes
                        .Any(x => x.RoomType.ToLower() == TblRoomTyp.RoomType.ToLower());
                    if (!DuplicateRoomType)
                    {
                        TblRoomTyp.VersionNo = 1;
                        TblRoomTyp.CreatedBy = 1;
                        TblRoomTyp.UpdatedBy = 1;
                        TblRoomTyp.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        TblRoomTyp.IsActive = true;


                        _ = await connection.tblRoomTypes.AddAsync(TblRoomTyp);
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

        public async Task<APIResponseModel> delete(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblRoomTypeModel? data = await connection.tblRoomTypes
                        .Where(x => x.RoomTypeId == id). FirstOrDefaultAsync();

                    if (data != null)
                    {
                        //connection.Database.BeginTransaction();
                        _tblRoomTypeFacilityMapping?.Deletebyroomid(connection,id);

                        _tblRoom?.Deletebyroomid(connection,id);

                        _tblRoomLocations?.Deletebyroomid(connection,id);

                        _tblPatientAdmitionDetails?.Deletebyroomid(connection,id);
                        


                        connection.tblRoomTypes.Remove(data);
                        connection.SaveChanges();
                        //connection.Database.CommitTransaction();
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete SuccessFully:";
                    }
                    else
                    {
                        //connection.Database.RollbackTransaction();
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


       





        public async Task<APIResponseModel> Update(TblRoomTypeModel id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {

                    TblRoomTypeModel? Data = await connection.tblRoomTypes.Where(x => x.RoomTypeId == id.RoomTypeId).FirstOrDefaultAsync();
                    if (Data != null)   
                    {
                        Data.RoomType = id.RoomType;
                        connection.tblRoomTypes.Update(Data);
                        Data.IncreamentVersion();
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


        public async Task<APIResponseModel> GetByID(int id)
        {
            APIResponseModel responseModel = new();
            TblRoomTypeModel data = new TblRoomTypeModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    data = await connection.tblRoomTypes.Where(x => x.RoomTypeId == id)
                        .FirstAsync();
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
            List<GetTblRoomTypeViewModel> lstRoomType = new ();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRoomType = connection.GetTblRoomTypeViewModel.FromSqlRaw($@"
                    SELECT tu.FullName AS CreatedBy, uu.FullName AS UpdatedBy, tr.RoomTypeId, 
                    tr.RoomType,tr.CreatedOn,tr.UpdatedOn, tr.IsActive,tr.VersionNo
                    FROM TblRoomType tr INNER JOIN TblUser tu ON tu.UserId = tr.CreatedBy  
                    INNER JOIN TblUser uu ON uu.UserId = tr.UpdatedBy 
                    where tu.fullName LIKE  '%{searchBy}%'").ToList();
                    responseModel.Data = lstRoomType;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Successfully";

                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException?.Message ?? ex.Message;
                responseModel.Data = null;
            }

            return responseModel;
        }

    }

}
