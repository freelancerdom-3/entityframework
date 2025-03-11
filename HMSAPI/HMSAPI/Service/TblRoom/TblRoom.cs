using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblRoom;
using HMSAPI.Model.TblRoom.View_Model;
using HMSAPI.Model.TblRoomTypeFacilityMapping.View_Model;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblRoom
{
    
    
        public class TblRoom : ITblRoom
        {
            private readonly HSMDBContext _hsmDbContext;

            public TblRoom(HSMDBContext hsmDbContext)
            {
                _hsmDbContext = hsmDbContext;
            }

                 

            public async Task<APIResponseModel> Add(TblRoomModel TblRoom)
            {
                APIResponseModel responseModel = new();
                try
                {
                    using (var connection = _hsmDbContext)
                    {
                        bool DuplicateRoom = connection.TblRoom
                            .Any(x => x.RoomNumber == TblRoom.RoomNumber);
                        if (!DuplicateRoom)
                        {
                             TblRoom.VersionNo = 1;
                            _ = await connection.TblRoom.AddAsync(TblRoom);
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
                        TblRoomModel? Data = await connection.TblRoom.Where(x => x.RoomID == id).FirstAsync();

                        if (Data != null)
                        {
                            Data.IncreamentVersion();
                            connection.TblRoom.Update(Data);
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
                            connection.TblRoom.Remove(data);
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
            List<GetTblRoomModel> lstTblRoomView = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstTblRoomView = await connection.GetTblRoomModel.FromSqlRaw($@"select TblRoom.RoomID,tblroomtype.RoomTypeId,TblRoomType.RoomType from TblRoom
                    inner join TblRoomType on TblRoomType.RoomTypeId = TblRoomType.RoomTypeId   where RoomType
                    like '%{searchBy}%'").ToListAsync();
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
                TblRoomModel data = new();
                try
                {
                    using (var connection = _hsmDbContext)
                    {
                        data = await connection.TblRoom.Where(x => x.RoomID == id)
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


        }
}

