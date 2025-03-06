using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Service.RoomType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net;

namespace HMSAPI.Service.TblRoomType
{
    public class TblRoomType : ITblRoomType
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblRoomType(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
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
                        .Where(x => x.RoomTypeId == id).FirstOrDefaultAsync();
                  
                    if (data != null)
                    {
                        connection.tblRoomTypes.Remove(data);
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



        public async Task<APIResponseModel> Update(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblRoomTypeModel? Data = await connection.tblRoomTypes.Where(x => x.RoomTypeId == id).FirstAsync();

                    if (Data != null)
                    {
                        connection.tblRoomTypes.Update(Data);
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
            List<TblRoomTypeModel> lstRoomType = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRoomType = string.IsNullOrEmpty(searchBy) ? await connection.tblRoomTypes.ToListAsync() :
                        await connection.tblRoomTypes.Where(x => x.RoomType.ToLower() == searchBy.ToLower()).ToListAsync();
                }
                if (lstRoomType != null)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get All Recode Successfull";
                    responseModel.Data = lstRoomType;

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
