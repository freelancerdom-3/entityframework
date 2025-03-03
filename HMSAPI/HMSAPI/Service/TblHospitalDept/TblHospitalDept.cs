using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalDep;
//using HMSAPI.Model.TblUser;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace HMSAPI.Service.TblHospitalDept
{
    public class TblHospitalDept : ITblHospitalDept
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblHospitalDept(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public async Task<APIResponseModel> AddDepartment(TblHospitalDeptModel deptModel)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicateDepartment = connection.TblHospitalDepts
                        .Any(x => x.Department.ToLower() == deptModel.Department.ToLower());

                    if (!duplicateDepartment)
                    {
                        //#1
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



        public bool UpdateDepartment(int id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                TblHospitalDeptModel? data = connection.TblHospitalDepts.Where(x => x.DeptId == id).FirstOrDefault();

                //update
                if (data != null)
                {
                    data.Department = "Neurology1 Department";
                    connection.TblHospitalDepts.Update(data);
                    connection.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;


        }
        public bool DeleteDepartment(int id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                TblHospitalDeptModel? data = connection.TblHospitalDepts.Where(x => x.DeptId == id).FirstOrDefault();

                //update
                if (data != null)
                {

                    connection.TblHospitalDepts.Remove(data);
                    connection.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;

        }

        public TblHospitalDeptModel GetDepartmentByID(int id)
        {
            //   bool result = false;
            using (var connection = _hsmDbContext)
            {


                TblHospitalDeptModel? data = connection.TblHospitalDepts.Where(x => x.DeptId == id).FirstOrDefault();


                return data;
            }
        }

        public List<TblHospitalDeptModel> GetAllDepartment(string? searchBy = null)
        {
            List<TblHospitalDeptModel> lstUsers = new();
            using (var connection = _hsmDbContext)
            {
                lstUsers = string.IsNullOrEmpty(searchBy) ? connection.TblHospitalDepts.ToList() :
                    connection.TblHospitalDepts.Where(x => x.Department.ToLower() == searchBy.ToLower()).
                    ToList();
            }
            return lstUsers;
        }



    }
}

