using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblHospitalDepartment;

//using HMSAPI.Model.TblUser;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace HMSAPI.Service.TblHospitalDept
{
    public class TblHospitalDepartment : ITblHospitalDepartment
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblHospitalDepartment(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

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
                        deptModel.VersionNo = 1;
                        _ = await connection.TbLHospitalDepartment.AddAsync(deptModel);
                        connection.SaveChanges();
                        //#3
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
        //public async Task<APIResponseModel> Add(TblHospitalDepartmentModel deptModel)
        //{
        //    APIResponseModel responseModel = new();
        //    try
        //    {
        //        bool duplicateDepartment = _hsmDbContext.TbLHospitalDepartment
        //            .Any(x => x.DepartmentName.ToLower() == deptModel.DepartmentName.ToLower());

            //        if (!duplicateDepartment)
            //        {
            //            deptModel.VersionNo = 1;
            //            await _hsmDbContext.TbLHospitalDepartment.AddAsync(deptModel);
            //            await _hsmDbContext.SaveChangesAsync();

            //            responseModel.Data = deptModel; // Return the inserted department
            //            responseModel.StatusCode = HttpStatusCode.OK;
            //            responseModel.Message = "Inserted Successfully";
            //        }
            //        else
            //        {
            //            responseModel.StatusCode = HttpStatusCode.BadRequest;
            //            responseModel.Message = "Duplicate Name Found";
            //            responseModel.Data = false;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        responseModel.StatusCode = HttpStatusCode.InternalServerError;
            //        responseModel.Message = ex.InnerException?.Message ?? ex.Message;
            //        responseModel.Data = null;
            //    }
            //    return responseModel;
            //}




        public async Task<APIResponseModel> Update(TblHospitalDepartmentModel departmentModel)
        {
            APIResponseModel responseModel = new();
            try
            {

                using (var connection = _hsmDbContext)
                {
                    TblHospitalDepartmentModel? data = await connection.TbLHospitalDepartment.Where(x => x.HospitalDepartmentId == departmentModel.HospitalDepartmentId).FirstOrDefaultAsync();

                    //update
                    if (data != null)
                    {
                        data.DepartmentName = departmentModel.DepartmentName;
                        connection.TbLHospitalDepartment.Update(data);
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

                    //delete
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

        //public async Task<APIResponseModel> GetAll(string? searchBy = null)
        //{
        //    APIResponseModel responseModel = new();
        //    List<TblHospitalDepartmentViewModel> lstUsers = new List<TblHospitalDepartmentViewModel> ();
        //    try
        //    {
        //        using (var connection = _hsmDbContext)
        //        {
        //            //lstUsers = string.IsNullOrEmpty(searchBy) ? await connection.TbLHospitalDepartment.ToListAsync() :
        //            //   await connection.TbLHospitalDepartment.Where(x => x.DepartmentName.ToLower() == searchBy.ToLower()).
        //            //    ToListAsync();


        //            lstUsers = connection.TblHospitalDepartmentViewModel.FromSqlRaw($@"
        //                SELECT tu.FullName AS CreatedBy, 
        //                uu.FullName AS UpdatedBy, 
        //                thd.HospitalDepartmentID, 
        //                thd.DepartmentName, 
        //                thd.CreatedOn, 
        //                thd.UpdateOn, 
        //                thd.IsActive, 
        //                thd.VersionNo
        //                FROM TbLHospitalDepartment thd 
        //                LEFT JOIN TblUser tu ON tu.UserId = thd.CreateBy  
        //                LEFT JOIN TblUser uu ON uu.UserId = thd.UpdateBy 
        //                WHERE tu.FullName LIKE '%{searchBy}%'").ToList();

        //            responseModel.Data = lstUsers;
        //            responseModel.StatusCode = HttpStatusCode.OK;
        //            responseModel.Message = "Successfully";

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        responseModel.StatusCode = HttpStatusCode.InternalServerError;
        //        responseModel.Message = ex.InnerException?.Message ?? ex.Message;
        //        responseModel.Data = null;
        //    }

        //    return responseModel;
        //}
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
                    thd.UpdateOn, 
                    thd.IsActive, 
                    thd.VersionNo
                FROM TbLHospitalDepartment thd 
                LEFT JOIN TblUser tu ON tu.UserId = thd.CreateBy  
                LEFT JOIN TblUser uu ON uu.UserId = thd.UpdateBy")  
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
                    // Find all child records linked to this parent
                    var childRecords = await connection.TblEmployeeDepartmentMappings
                        .Where(x => x.HospitalDepartmentId == hospitalDepartmentID)
                        .ToListAsync();

                    // Remove all child records first
                    if (childRecords.Any())
                    {
                        connection.TblEmployeeDepartmentMappings.RemoveRange(childRecords);
                        await connection.SaveChangesAsync();
                    }

                    // Find and delete the parent record
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

