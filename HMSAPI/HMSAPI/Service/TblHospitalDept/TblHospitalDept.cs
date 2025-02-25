using HMSAPI.EFContext;
using HMSAPI.Model.TblHospitalDep;
//using HMSAPI.Model.TblUser;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace HMSAPI.Service.TblHospitalDept
{
    public class TblHospitalDept : ITblHospitalDept
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblHospitalDept(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public bool AddDepartment(TblHospitalDeptModel deptModel)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                bool duplicateDepartment = connection.TblHospitalDepts
                    .Any(x => x.Department.ToLower() == deptModel.Department.ToLower());


                if (!duplicateDepartment)
                {
                    //#1
                    _ = connection.TblHospitalDepts.Add(deptModel);
                    connection.SaveChanges();
                    //#3
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;

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

