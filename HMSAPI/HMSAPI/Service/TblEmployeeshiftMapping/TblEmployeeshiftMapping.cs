using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblEmployeeshiftMapping;
using HMSAPI.Model.TblEmployeeshiftMapping.ViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblEmployeeshiftMapping
{
    public class TblEmployeeshiftMapping : ITblEmployeeshiftMapping
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;

        public TblEmployeeshiftMapping(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;
        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);

        public async Task<APIResponseModel> Add(TblEmployeeshiftMappingModel objModel)
        {
            APIResponseModel responseModel = new();


            try
            {
                using (var connection = _hsmDbContext)
                {
                    if (objModel.EmployeeshiftMappingStartingDate == null || objModel.EmployeeshiftMappingEndingDate == null)
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Start Date & End Date Are Required";
                        responseModel.Data = false;
                    }
                    else
                    {
                        var existShiftData = connection.TblEmployeeshifts.Where(x => x.ShiftId == objModel.ShiftId && (
                             x.EmployeeshiftMappingStartingDate.Value.Date <= objModel.EmployeeshiftMappingEndingDate.Value.Date &&
                             x.EmployeeshiftMappingEndingDate.Value.Date >= objModel.EmployeeshiftMappingEndingDate.Value.Date)).FirstOrDefault();

                        if (existShiftData != null)
                        {

                            responseModel.StatusCode = HttpStatusCode.BadRequest;
                            responseModel.Message = "Data Already Exist";
                            responseModel.Data = false;
                        }
                        else
                        {
                            objModel.CreatedBy = UserId;
                            objModel.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            objModel.VersionNo = 1;
                            _ = await connection.TblEmployeeshifts.AddAsync(objModel);

                            connection.SaveChanges();
                            responseModel.Data = true;
                            responseModel.StatusCode = HttpStatusCode.OK;
                            responseModel.Message = "Data Added Successfully";
                        }
                    }

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


       


        public async Task<APIResponseModel> delete(int id)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblEmployeeshiftMappingModel? data = await connection.TblEmployeeshifts.Where(x => x.EmployeeshiftMappingId == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.TblEmployeeshifts.Remove(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Id Not Found";
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

        public async Task<APIResponseModel> DeleteByShiftId(HSMDBContext context, int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                List<TblEmployeeshiftMappingModel> empshiftid = context.TblEmployeeshifts.Where(x => x.ShiftId == id).ToList();

                if (empshiftid != null)
                {
                    foreach(TblEmployeeshiftMappingModel mappingModel in empshiftid)
                    {
                        context.TblEmployeeshifts.Remove(mappingModel);
                    }
                }
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Deleted Successfully";
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
            APIResponseModel responseModel = new APIResponseModel();

            List<GetEmployeeMapping> lstEmployeeshiftMapping = new();
            try
            {
                using (var connection = _hsmDbContext)
                {

                   lstEmployeeshiftMapping = await connection.getEmployeeMappings.FromSqlRaw($@"
                    select TblUser.FullName,TblShift.Shiftname,te.EmployeeshiftMappingId,te.EmployeeshiftMappingStartingDate,
                    te.EmployeeshiftMappingEndingDate,tu.FullName as CreatedBy,te.CreatedOn,tt.FullName as UpdatedBy,te.UpdatedOn,
                    te.IsActive,te.VersionNo from TblEmployeeshiftMapping te
                    inner join TblUser tu on tu.UserId = te.CreatedBy
                    left join  TblUser tt on tt.UserId = te.UpdatedBy
                    inner join TblShift on TblShift.ShiftId=te.ShiftId
                    inner join TblUser on TblUser.UserId=te.UserId
                    where TblUser.FullName like '%{searchBy}%'").ToListAsync();

                    responseModel.Data = lstEmployeeshiftMapping;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Data retrieved successfully.";
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

        public async Task<APIResponseModel> GetById(int id)
        {
            APIResponseModel responseModel = new APIResponseModel();

            try
            {
                TblEmployeeshiftMappingModel? data = new();
                using (var connection = _hsmDbContext)

                {
                    data = await connection.TblEmployeeshifts.Where(x => x.EmployeeshiftMappingId == id).FirstOrDefaultAsync();

                    if (data != null)
                    {
                        responseModel.Data = new { 
                            data.EmployeeshiftMappingStartingDate,
                            data.EmployeeshiftMappingEndingDate,
                            data.UserId,
                            data.ShiftId,
                            };
                        responseModel.StatusCode = HttpStatusCode.OK;

                        responseModel.Message = "Your information";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Id Not Found";
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

        public async Task<APIResponseModel> Update(TblEmployeeshiftMappingModel employeeshiftmapping)
        {

            APIResponseModel responseModel = new();

            try
            {
                using (var connection = _hsmDbContext)
                {


                    TblEmployeeshiftMappingModel? data = await connection.TblEmployeeshifts.Where(x => x.EmployeeshiftMappingId == employeeshiftmapping.EmployeeshiftMappingId 
                    && x.UserId == employeeshiftmapping.UserId &&
                    x.ShiftId != employeeshiftmapping.ShiftId
                    && (
                             x.EmployeeshiftMappingStartingDate.Value.Date <= employeeshiftmapping.EmployeeshiftMappingEndingDate.Value.Date &&
                             x.EmployeeshiftMappingEndingDate.Value.Date >= employeeshiftmapping.EmployeeshiftMappingEndingDate.Value.Date)
                    ).FirstOrDefaultAsync();


                    if (data != null)
                    {
                        employeeshiftmapping.UpdatedBy = UserId;
                        employeeshiftmapping.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        data.EmployeeshiftMappingStartingDate = employeeshiftmapping.EmployeeshiftMappingStartingDate;
                        data.EmployeeshiftMappingEndingDate = employeeshiftmapping.EmployeeshiftMappingEndingDate;
                        data.UserId = employeeshiftmapping.UserId;
                        data.ShiftId = employeeshiftmapping.ShiftId;
                        data.UpdatedBy = employeeshiftmapping.UpdatedBy;
                        data.UpdatedOn  = employeeshiftmapping.UpdatedOn;
                        data.IsActive = data.IsActive;
                        data.IncreamentVersion();
                        connection.TblEmployeeshifts.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Allready exixt";
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
