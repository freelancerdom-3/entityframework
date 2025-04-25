
using HMSAPI.Model.TblShift;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using System.Net;
using Microsoft.EntityFrameworkCore;
using HMSAPI.Service.TblEmployeeshiftMapping;
using HMSAPI.Service.TokenData;
namespace HMSAPI.Service.TblShift

{
    public class TblShift : ITblShift
    {

        private readonly HSMDBContext _hsmDbContext;
        private readonly ITblEmployeeshiftMapping _tblEmployeeshiftMapping;
        private readonly ITokenData _tokenData;
        //private object connection;

        public TblShift(HSMDBContext hSMDBContext, ITblEmployeeshiftMapping tblEmployeeshiftMapping, ITokenData tokenData)
        {
            _hsmDbContext = hSMDBContext;
            _tblEmployeeshiftMapping = tblEmployeeshiftMapping;
            _tokenData = tokenData;
        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);


        public async Task<APIResponseModel> Add(TblShiftModel Shift)
        {
            APIResponseModel responseModel = new();

            try
            {
                using (var connection = _hsmDbContext)
                {

                    

                    bool DuplicateShift = connection.TblShifts.Any(x => x.Shiftname.ToLower() == Shift.Shiftname.ToLower());

                    if (!DuplicateShift)
                    {
                        Shift.CreatedBy = UserId;
                        Shift.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        Shift.VersionNo = 1;
                        Shift.IsActive = true;
                        connection.TblShifts.Add(Shift);
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

        public async Task<APIResponseModel> Delete(int id)
        {
            APIResponseModel responseModel = new();

            try
            {
                using (var connection = _hsmDbContext)
                {

                    TblShiftModel? data = connection.TblShifts.Where(j => j.ShiftId == id).FirstOrDefault();

                    if (data != null)
                    {
                        data.IsActive = false;
                        connection.TblShifts.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";
                    }

                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Enter Valid Number";
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

           // List<TblShiftModel> shitList = new();
            List<GetTblShiftViewModel> list = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    list = connection.GetTblShiftViewModel.FromSqlRaw($@"
                select tu.FullName as Createdby, uu.FullName as UpdatedBy, tr.ShiftId,
                tr.StartTime,tr.EndTime,tr.Shiftname,tr.CreatedOn,tr.UpdatedOn,tr.IsActive,tr.VersionNo 
                from TblShift tr inner join TblUser tu on tu.UserId = tr.CreatedBy
                left join TblUser uu on uu.UserId = tr.UpdatedBy 
                where tr.IsActive = 1 and tu.FullName like  '%{searchBy}%'").ToList();
                    responseModel.Data = list;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Inserted Successfully";
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

           // TblShiftModel data = new TblShiftModel();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblShiftModel? data = await connection.TblShifts.Where(x => x.ShiftId == id && x.IsActive == true).FirstOrDefaultAsync();
                    responseModel.Data = new
                    {
                      data.ShiftId,
                      data.StartTime,
                      data.EndTime,
                      data.Shiftname,
                    };
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "done";


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

        public async Task<APIResponseModel> Update(TblShiftModel model)
        {
            APIResponseModel responseModel = new();

            try
            {
                using (var connection = _hsmDbContext)
                {

                    TblShiftModel? data = await connection.TblShifts.Where(x => x.ShiftId == model.ShiftId).FirstOrDefaultAsync();

                    if (data != null)
                    {
                        model.UpdatedBy = UserId;
                        model.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        data.Shiftname = model.Shiftname;
                        data.UpdatedBy = model.UpdatedBy;
                        data.UpdatedOn = model.UpdatedOn;
                        data.StartTime = model.StartTime;
                        data.EndTime = model.EndTime;
                        data.IncreamentVersion();
                        connection.TblShifts.Update(data);
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
