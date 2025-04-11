using HMSAPI.EFContext;
using HMSAPI.Model.Enums;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblEmployeeDepartmentMapping;
using HMSAPI.Model.TblEmpyloeeDepartmentMapping.ViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static HMSAPI.Model.Enums.Enums;

namespace HMSAPI.Service.TblEmployeeDepartmentMapping
{
    public class TblEmployeeDepartmentMapping : ITblEmployeeDepartmentMapping
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;
        public TblEmployeeDepartmentMapping(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;
        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);

        public async Task<APIResponseModel> Add(TblEmployeeDepartmentMappingModel deptModel)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {

                    bool duplicateUserId = connection.TblEmployeeDepartmentMappings
                        .Any(x => x.UserId == deptModel.UserId);

                    if (!duplicateUserId)
                    {
                        //#1
                        deptModel.CreatedBy = UserId;
                        deptModel.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        deptModel.VersionNo = 1;
                        _ = await connection.TblEmployeeDepartmentMappings.AddAsync(deptModel);
                        connection.SaveChanges();
                        //#3
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate Id Found";
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

        public async Task<APIResponseModel> Update(TblEmployeeDepartmentMappingModel departmentModel)
            {
            APIResponseModel responseModel = new();
              try
                {

                using (var connection = _hsmDbContext)
                {
                    TblEmployeeDepartmentMappingModel? data = await connection.TblEmployeeDepartmentMappings.Where(x => x.UserId == departmentModel.UserId).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        departmentModel.UpdatedBy = UserId; 
                        departmentModel.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        data.UpdatedBy = departmentModel.UpdatedBy;
                        data.UpdatedOn = departmentModel.UpdatedOn;
                        data.HospitalDepartmentId = departmentModel.HospitalDepartmentId;
                        connection.TblEmployeeDepartmentMappings.Update(data);
                        data.IncreamentVersion();
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Updated Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Department ID Not Found";
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
                    TblEmployeeDepartmentMappingModel? data = await connection.TblEmployeeDepartmentMappings.Where(x => x.EmployeeDepartmentMappingId == id).FirstOrDefaultAsync();
                    if (data != null)
                    {

                        connection.TblEmployeeDepartmentMappings.Remove(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Deleted Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Department ID Not Found";
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

            List<TblEmployeeDepartment> lstUsers = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstUsers = await connection.tblEmployeeDepartments.FromSqlRaw($@"SELECT 
                    tblmapping.EmployeeDepartmentMappingID,
                    Tuser.FullName,
                    th.DepartmentName,
                    tu.FullName AS CreatedBy,
                    tuu.FullName AS UpdatedBy,
                    tblmapping.CreatedOn,
                    tblmapping.UpdatedOn,
                    tblmapping.VersionNo,
                    tblmapping.IsActive
                    FROM TblEmployeeDepartmentMapping tblmapping 
                    INNER JOIN TblUser Tuser ON Tuser.UserId = tblmapping.UserId
                    INNER JOIN TbLHospitalDepartment th ON th.HospitalDepartmentID = tblmapping.HospitalDepartmentID
                    LEFT JOIN TblUser tu ON tu.UserId = tblmapping.CreatedBy
                    LEFT JOIN TblUser tuu ON tuu.UserId = tblmapping.UpdatedBy
                    where Tuser.FullName like '%{searchBy}%'").ToListAsync();
                    responseModel.Data = lstUsers;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get Record Successfully";
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
            TblEmployeeDepartmentMappingModel data = new();
            try
            {

                using (var connection = _hsmDbContext)
                {
                     data = await connection.TblEmployeeDepartmentMappings.Where(x => x.EmployeeDepartmentMappingId == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Get Record Successfully";
                        responseModel.Data = data;
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Department ID Not Found";
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

        public async Task<APIResponseModel> DeleteByID(int employeeDepartmentMappingId)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                     var childRecord = await connection.TblEmployeeDepartmentMappings
                        .Where(x => x.EmployeeDepartmentMappingId == employeeDepartmentMappingId)
                        .FirstOrDefaultAsync();

                    if (childRecord != null)
                    {
                        int hospitalDepartmentID = childRecord.HospitalDepartmentId;
                        connection.TblEmployeeDepartmentMappings.Remove(childRecord);
                        await connection.SaveChangesAsync();
                        bool hasOtherMappings = await connection.TblEmployeeDepartmentMappings
                            .AnyAsync(x => x.HospitalDepartmentId == hospitalDepartmentID);

                        if (!hasOtherMappings)
                        {
                            var parentRecord = await connection.TbLHospitalDepartment
                                .Where(x => x.HospitalDepartmentId == hospitalDepartmentID)
                                .FirstOrDefaultAsync();

                            if (parentRecord != null)
                            {
                                connection.TbLHospitalDepartment.Remove(parentRecord);
                                await connection.SaveChangesAsync();
                            }
                        }

                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Child deleted successfully. Parent deleted if no more children exist.";
                        responseModel.Data = true;
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Child record not found.";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = "Error occurred: " + ex.Message;
                responseModel.Data = null;
            }

            return responseModel;
        }

    }
}
