using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblEmployeeshiftMapping;
using HMSAPI.Model.TblEmployeeshiftMapping.ViewModel;
using HMSAPI.Model.TblRole;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblEmployeeshiftMapping
{
    public class TblEmployeeshiftMapping : ITblEmployeeshiftMapping
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblEmployeeshiftMapping(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public async Task<APIResponseModel> Add(TblEmployeeshiftMappingModel objModel)
        {
            APIResponseModel responseModel = new();


            try
            {
                using (var connection = _hsmDbContext)
                {
                    if (objModel.EmployeeshiftMappingStartingDate == null || objModel.EmployeeshiftMappingEndingData == null)
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Start Date & End Date Are Required";
                        responseModel.Data = false;
                    }
                    else
                    {
                        var existShiftData = connection.TblEmployeeshifts.Where(x => x.ShiftId == objModel.ShiftId && (
                             x.EmployeeshiftMappingStartingDate.Value.Date <= objModel.EmployeeshiftMappingEndingData.Value.Date &&
                             x.EmployeeshiftMappingEndingData.Value.Date >= objModel.EmployeeshiftMappingStartingDate.Value.Date)).FirstOrDefault();

                        if (existShiftData != null)
                        {

                            responseModel.StatusCode = HttpStatusCode.BadRequest;
                            responseModel.Message = "Data Already Exist";
                            responseModel.Data = false;
                        }
                        else
                        {

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

                // responseModel.Message = ex.InnerException.Message;
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
                    // TblRoleModel? data = await connection.TblRoles.Where(x => x.RoleId == id).FirstOrDefaultAsync();

                    TblEmployeeshiftMappingModel? data = await connection.TblEmployeeshifts.Where(x => x.EmployeeshiftMappingId == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        //connection.TblRoles.Remove(data);
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

            List<GetTblEmployeeshiftMappingViewModel> lstEmployeeshiftMapping = new();



            try
            {
                using (var connection = _hsmDbContext)
                {

                   lstEmployeeshiftMapping = await connection.getTblEmployeeshiftMappingViewModel.FromSqlRaw($@"select TblEmployeeshiftMapping.*,TblUser.FullName,TblShift.Shiftname from TblEmployeeshiftMapping 
inner join TblShift on TblShift.ShiftId=TblEmployeeshiftMapping.ShiftId
inner join TblUser on TblUser.UserId=TblEmployeeshiftMapping.UserId where FullName like '%{searchBy}%'").ToListAsync();

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

            //data on notepad

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
                            data.EmployeeshiftMappingEndingData,
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


                    TblEmployeeshiftMappingModel? data = await connection.TblEmployeeshifts.Where(x => x.EmployeeshiftMappingId == employeeshiftmapping.EmployeeshiftMappingId && x.UserId!=employeeshiftmapping.UserId && x.ShiftId!=employeeshiftmapping.ShiftId).FirstOrDefaultAsync();

                    if (data != null)
                    {

                        data.EmployeeshiftMappingStartingDate = employeeshiftmapping.EmployeeshiftMappingStartingDate;
                        data.EmployeeshiftMappingEndingData = employeeshiftmapping.EmployeeshiftMappingEndingData;
                        data.UserId = employeeshiftmapping.UserId;
                        data.ShiftId = employeeshiftmapping.ShiftId;
                        data.UpdateBy = data.UpdateBy;
                        data.UpdateOn  = data.UpdateOn;
                        data.IsActive = data.IsActive;
                        data.IncreamentVersion();
                        // connection.TblRoles.Update(data);
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
