using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRoom;
using HMSAPI.Model.TblRoomLocation;
using HMSAPI.Model.TblRoomTypeFacilityMapping.View_Model;
using HMSAPI.Service.TblRoom;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblRoomLocations
{
        public class TblRoomLocations : ITblRoomLocations
        {
            private readonly HSMDBContext _hsmDbContext;

            public TblRoomLocations(HSMDBContext hsmDbContext)
            {
                _hsmDbContext = hsmDbContext;
            }

            public async Task<APIResponseModel> Update(int id)
            {
                APIResponseModel responseModel = new();
                try
                {
                    using (var connection = _hsmDbContext)
                    {
                        TblRoomLocationModel? Data = await connection.TblRoomLocations.Where(x => x.RoomLocationID == id).FirstAsync();

                        if (Data != null)
                        {
                            Data.IncreamentVersion();
;                           connection.TblRoomLocations.Update(Data);
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
                        TblRoomLocationModel? data = await connection.TblRoomLocations
                            .Where(x => x.RoomLocationID == id).FirstOrDefaultAsync();

                        if (data != null)
                        {
                            connection.TblRoomLocations.Remove(data);
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
            List<GetTblRoomTypeFacilityMappingModel> lsttblRoomTypeFacilityMappings = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lsttblRoomTypeFacilityMappings = await connection.GetTblRoomTypeFacilityMappingModel.FromSqlRaw($@"select TblRoom.RoomID,tblroomtype.RoomTypeId,TblRoomType.RoomType from TblRoom
                    inner join TblRoomType on TblRoomType.RoomTypeId = TblRoomType.RoomTypeId   where RoomType
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


        public async Task<APIResponseModel> GetByID(int id)
            {
                APIResponseModel responseModel = new();
                TblRoomLocationModel data = new();
                try
                {
                    using (var connection = _hsmDbContext)
                    {
                        data = await connection.TblRoomLocations.Where(x => x.RoomLocationID == id)
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

            public async Task<APIResponseModel> Add(TblRoomLocationModel tblRoomLocation)
            {
                APIResponseModel responseModel = new();
                try
                {
                    using (var connection = _hsmDbContext)
                    {
                        bool DuplicateRoomLocation = connection.TblRoomLocations
                            .Any(x => x.Floornumber == tblRoomLocation.Floornumber);
                        if (!DuplicateRoomLocation)
                        {
                             tblRoomLocation.VersionNo = 1;
                            _ = await connection.TblRoomLocations.AddAsync(tblRoomLocation);
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
        }
    }

    




