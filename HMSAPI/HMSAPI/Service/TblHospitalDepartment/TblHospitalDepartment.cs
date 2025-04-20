using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalDepartment;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace HMSAPI.Service.TblHospitalDept
{
    public class TblHospitalDepartment : ITblHospitalDepartment
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;

        public TblHospitalDepartment(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;
        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);

        public async Task<APIResponseModel> Add(TblHospitalDepartmentModel deptModel)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicateDepartment = connection.TbLHospitalDepartment
                        .Any(x => x.DepartmentName.ToLower() == deptModel.DepartmentName.ToLower());

                    if (!duplicateDepartment)
                    {
                        deptModel.CreatedBy = UserId;
                        deptModel.CreatedOn= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        deptModel.VersionNo = 1;
                        deptModel.IsActive = true;
                        _ = await connection.TbLHospitalDepartment.AddAsync(deptModel);
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




        public async Task<APIResponseModel> Update(TblHospitalDepartmentModel departmentModel)
        {
            APIResponseModel responseModel = new();
            try
            {

                using (var connection = _hsmDbContext)
                {
                    TblHospitalDepartmentModel? data = await connection.TbLHospitalDepartment.Where(x => x.HospitalDepartmentId == departmentModel.HospitalDepartmentId).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        departmentModel.UpdatedBy = UserId;
                        departmentModel.UpdatedOn= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        data.DepartmentName = departmentModel.DepartmentName;
                        connection.TbLHospitalDepartment.Update(data);
                        data.UpdatedBy = departmentModel.UpdatedBy;
                        data.UpdatedOn = departmentModel.UpdatedOn;
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
                    TblHospitalDepartmentModel? data = await connection.TbLHospitalDepartment.Where(x => x.HospitalDepartmentId == id).FirstOrDefaultAsync();
                    if (data != null)
                    {

                        connection.TbLHospitalDepartment.Remove(data);
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

        public async Task<APIResponseModel> GetByID(int id)
        {
            APIResponseModel responseModel = new();
            TblHospitalDepartmentModel data = new TblHospitalDepartmentModel();
            try
            {

                using (var connection = _hsmDbContext)
                {
                    data = await connection.TbLHospitalDepartment.FindAsync(id);
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

        
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            List<TblHospitalDepartmentViewModel> lstUsers = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstUsers = connection.TblHospitalDepartmentViewModel.FromSqlRaw(@"
                SELECT 

                    tu.FullName AS CreatedBy, 
                    uu.FullName AS UpdatedBy, 
                    thd.HospitalDepartmentID, 
                    thd.DepartmentName, 
                    thd.CreatedOn, 
                    thd.UpdatedOn, 
                    thd.IsActive, 
                    thd.VersionNo
                FROM TbLHospitalDepartment thd 
                LEFT JOIN TblUser tu ON tu.UserId = thd.CreatedBy  
                LEFT JOIN TblUser uu ON uu.UserId = thd.UpdatedBy")  
                    .ToList();

                    Console.WriteLine($"Records fetched: {lstUsers.Count}");

                    foreach (var item in lstUsers)
                    {
                        Console.WriteLine($"ID: {item.HospitalDepartmentId}, Name: {item.DepartmentName}");
                    }
                    responseModel.Data = lstUsers;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Successfully Retrieved";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException?.Message ?? ex.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> DeleteByID(int hospitalDepartmentID)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    var childRecords = await connection.TblEmployeeDepartmentMappings
                        .Where(x => x.HospitalDepartmentId == hospitalDepartmentID)
                        .ToListAsync();

                    if (childRecords.Any())
                    {
                        connection.TblEmployeeDepartmentMappings.RemoveRange(childRecords);
                        await connection.SaveChangesAsync();
                    }

                    var parentRecord = await connection.TbLHospitalDepartment
                        .Where(x => x.HospitalDepartmentId == hospitalDepartmentID)
                        .FirstOrDefaultAsync();

                    if (parentRecord != null)
                    {
                        connection.TbLHospitalDepartment.Remove(parentRecord);
                        await connection.SaveChangesAsync();

                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Parent and all related children deleted successfully.";
                        responseModel.Data = true;
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Parent record not found.";
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

