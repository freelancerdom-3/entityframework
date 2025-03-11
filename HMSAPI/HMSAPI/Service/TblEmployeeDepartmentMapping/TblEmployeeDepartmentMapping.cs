using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblEmployeeDepartmentMapping;
using HMSAPI.Model.TblEmpyloeeDepartmentMapping.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblEmployeeDepartmentMapping
{
    public class TblEmployeeDepartmentMapping : ITblEmployeeDepartmentMapping
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblEmployeeDepartmentMapping(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }
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

                    //update
                    if (data != null)
                    {
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

                    //delete
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

            List<GetTblEmployeeDepartmentmappingViewModel> lstUsers = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstUsers = await connection.GetTblEmployeeDepartmentMappingViewModel.FromSqlRaw($@"select tblmapping.EmployeeDepartmentMappingID,Tuser.FullName,thos.DepartmentName from TblEmployeeDepartmentMapping tblmapping
                               inner join TblUser Tuser on Tuser.UserId = tblmapping.UserId
                               inner join TbLHospitalDepartment thos on thos.HospitalDepartmentID=tblmapping
                               .HospitalDepartmentID where FullName like '%{searchBy}%'").ToListAsync();
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


    }
}
