using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFacility;
using HMSAPI.Model.TblRoom;
using HMSAPI.Model.TblRoom.View_Model;
using HMSAPI.Model.TblRoomTypeFacilityMapping.View_Model;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblRoom
{


    public class TblRoom : ITblRoom
        {
            private readonly HSMDBContext _hsmDbContext;
            private readonly ITokenData _tokenData;

        public TblRoom(HSMDBContext hsmDbContext, ITokenData tokendata)
            {
                _hsmDbContext = hsmDbContext;
                _tokenData = tokendata;
        }
        private int UserId => Convert.ToInt32(_tokenData.UserID);
        

        public async Task<APIResponseModel> Add(TblRoomModel TblRoom)
        {
            APIResponseModel responseModel = new();
            try
            {
                if (string.IsNullOrEmpty(TblRoom.RoomNumber.ToString()))
                {
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                    responseModel.Message = "RoomNumber cannot be null or empty.";
                    responseModel.Data = false;
                    return responseModel;
                }

                using (var connection = _hsmDbContext)
                {
                    bool DuplicateRoom = await connection.TblRoom
                        .AnyAsync(x => x.RoomNumber == TblRoom.RoomNumber);
                    Console.WriteLine($"RoomNumber: {TblRoom.RoomNumber}, IsDuplicate: {DuplicateRoom}");

                    if (!DuplicateRoom)
                    {
                        TblRoom.IsActive = true;
                        TblRoom.CreatedBy = UserId;
                        TblRoom.CreatedOn = DateTime.Now;
                        TblRoom.VersionNo = 1;
                        await connection.TblRoom.AddAsync(TblRoom);
                        await connection.SaveChangesAsync();
                        responseModel.Data = TblRoom.RoomID; // Return the generated RoomID
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate Room Found.";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException?.Message ?? ex.Message;
                responseModel.Data = null;
                Console.WriteLine($"Error: {ex}");
            }
            return responseModel;
        }

        //public async Task<APIResponseModel> Add(TblRoomModel TblRoom)
        //    {
        //        APIResponseModel responseModel = new();
        //        try
        //        {
        //            using (var connection = _hsmDbContext)
        //            {
        //                bool DuplicateRoom = await connection.TblRoom
        //                    .AnyAsync(x => x.RoomNumber == TblRoom.RoomNumber);
        //                if (!DuplicateRoom)
        //                {
        //                TblRoom.CreatedBy = UserId;
        //                TblRoom.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //                TblRoom.VersionNo = 1;
        //                    _ = await connection.TblRoom.AddAsync(TblRoom);
        //                    connection.SaveChanges();
        //                    responseModel.Data = true;
        //                    responseModel.StatusCode = HttpStatusCode.OK;
        //                    responseModel.Message = "Inserted Successfully";
        //                }
        //                else     
        //                {
        //                    responseModel.StatusCode = HttpStatusCode.BadRequest;
        //                    responseModel.Message = "Duplicate Name Found:";
        //                    responseModel.Data = false;

        //                }

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            responseModel.StatusCode = HttpStatusCode.InternalServerError;
        //            responseModel.Message = ex.InnerException.Message;
        //            responseModel.Data = null;
        //        }
        //        return responseModel;
        //    }


        public async Task<APIResponseModel> Update(TblRoomModel tblRoom)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblRoomModel? data = await connection.TblRoom.Where(x => x.RoomID == tblRoom.RoomID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        tblRoom.UpdatedBy = UserId;
                        tblRoom.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        data.RoomNumber = tblRoom.RoomNumber;
                        data.RoomTypeID = tblRoom.RoomTypeID;
                        data.UpdatedBy = tblRoom.UpdatedBy;
                        data.UpdatedOn = tblRoom.UpdatedOn;
                        data.IsActive = tblRoom.IsActive;
                        data.IncreamentVersion();
                        connection.TblRoom.Update(data);
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
        public async Task<APIResponseModel> Delete(int id)
            {
                APIResponseModel responseModel = new();
                try
                {
                    using (var connection = _hsmDbContext)
                    {
                        TblRoomModel? data = await connection.TblRoom
                            .Where(x => x.RoomID == id).FirstOrDefaultAsync();

                        if (data != null)
                        {
                            data.IsActive = false;
                            connection.TblRoom.Update(data);
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

     

        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            List<GetTblRoom> lstTblRoomView = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstTblRoomView = await connection.gettblroom.FromSqlRaw($@"
                   SELECT tr.RoomID, tu.FullName AS CreatedBy, uu.FullName AS UpdatedBy,tr.RoomNumber,
 tr.RoomTypeID,tr.CreatedOn,tr.UpdatedOn, tr.IsActive,tr.VersionNo,trt.RoomType
 FROM TblRoom tr
 INNER JOIN TblRoomType trt on trt.RoomTypeId = tr.RoomTypeID
 INNER JOIN TblUser tu ON tu.UserId = tr.CreatedBy 
 left JOIN TblUser uu ON uu.UserId = tr.UpdatedBy  
                    WHERE tu.FullName LIKE '%{searchBy}%'").ToListAsync();

                    
                    responseModel.Data = lstTblRoomView;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Successfully";
                }
                if (lstTblRoomView != null)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get All Recode Successfull";
                    responseModel.Data = lstTblRoomView;    

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


        public async Task<APIResponseModel> GetByID(int id)
            {
                APIResponseModel responseModel = new();
                TblRoomModel? data = new();
                try
                {
                    using (var connection = _hsmDbContext)
                    {
                    data = await connection.TblRoom.Where(x => x.RoomID == id && x.IsActive == true).FirstOrDefaultAsync();
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


        }
}

