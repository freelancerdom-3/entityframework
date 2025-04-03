
using HMSAPI.Model.TblShift;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using System.Net;
using Microsoft.EntityFrameworkCore;
using HMSAPI.Service.TblEmployeeshiftMapping;
namespace HMSAPI.Service.TblShift

{
    public class TblShift : ITblShift
    {

        private readonly HSMDBContext _hsmDbContext;
        private readonly ITblEmployeeshiftMapping _tblEmployeeshiftMapping;
        //private object connection;

        public TblShift(HSMDBContext hSMDBContext, ITblEmployeeshiftMapping tblEmployeeshiftMapping)
        {
            _hsmDbContext = hSMDBContext;
            _tblEmployeeshiftMapping = tblEmployeeshiftMapping;
        }

        public async Task<APIResponseModel> Add(TblShiftModel Shift)
        {
            APIResponseModel responseModel = new();

            try
            {
                using (var connection = _hsmDbContext)
                {

                    // bool duplicateRoleName = connection.TblRoles.Any(x => x.RoleName.ToLower() == roleModel.RoleName.ToLower());

                    bool DuplicateShift = connection.TblShifts.Any(x => x.Shiftname.ToLower() == Shift.Shiftname.ToLower());

                    if (!DuplicateShift)
                    {
                        Shift.CreateBy = 1;
                        //Shift.UpdateBy = 1;
                        Shift.CreatedOn = DateTime.Now;
                        Shift.VersionNo = 1;
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
                        _tblEmployeeshiftMapping?.DeleteByShiftId(connection, id);
                        connection.TblShifts.Remove(data);
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
                           tr.StartTime,tr.EndTime,tr.Shiftname,tr.CreatedOn,tr.UpdateOn,tr.IsActive,tr.VersionNo 
                           from TblShift tr inner join TblUser tu on tu.UserId = tr.CreateBy
                           left join TblUser uu on uu.UserId = tr.UpdateBy where tu.FullName like '%{searchBy}%'").ToList();
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
                   TblShiftModel? data= connection.TblShifts.Where(x=>x.ShiftId == id).FirstOrDefault();
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
                        //data.Shiftname = "Mornig Night";
                        data.Shiftname = model.Shiftname;
                        data.UpdateBy = model.UpdateBy;
                        data.UpdateOn = model.UpdateOn;
                        data.StartTime = model.StartTime;
                        data.EndTime = model.EndTime;
                        model.UpdateBy = 2;
                        model.UpdateOn = DateTime.Now;
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
