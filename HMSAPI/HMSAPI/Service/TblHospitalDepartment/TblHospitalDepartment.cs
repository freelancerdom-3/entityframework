using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
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
                    bool duplicateDepartment = connection.TblHospitalDepts
                        .Any(x => x.DepartmentName.ToLower() == deptModel.DepartmentName.ToLower());

                    if (!duplicateDepartment)
                    {
                        deptModel.VersionNo = 1;    
                        _ = await connection.TblHospitalDepts.AddAsync(deptModel);
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



        public async Task<APIResponseModel> Update(TblHospitalDepartmentModel departmentModel)
        {
            APIResponseModel responseModel = new();
            try
            {

                using (var connection = _hsmDbContext)
                {
                    TblHospitalDepartmentModel? data = await connection.TblHospitalDepts.Where(x => x.HospitalDepartmentId == departmentModel.HospitalDepartmentId).FirstOrDefaultAsync();

                    //update
                    if (data != null)
                    {
                        data.DepartmentName = departmentModel.DepartmentName;
                        connection.TblHospitalDepts.Update(data);
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
                    TblHospitalDepartmentModel? data = await connection.TblHospitalDepts.Where(x => x.HospitalDepartmentId == id).FirstOrDefaultAsync();

                    //delete
                    if (data != null)
                    {

                        connection.TblHospitalDepts.Remove(data);
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


                    data = await connection.TblHospitalDepts.FindAsync(id);



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

            List<TblHospitalDepartmentModel> lstUsers = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstUsers = string.IsNullOrEmpty(searchBy) ? await connection.TblHospitalDepts.ToListAsync() :
                       await connection.TblHospitalDepts.Where(x => x.DepartmentName.ToLower() == searchBy.ToLower()).
                        ToListAsync();
                }
                if (lstUsers != null)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get Record Successfully";
                    responseModel.Data = lstUsers;

                }
                else
                {
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                    responseModel.Message = "Department Not Found";
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

