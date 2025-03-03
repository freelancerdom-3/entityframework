using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalDep;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.TblHospitalDept
{
    public interface ITblHospitalDept
    {

        //APIResponseModel
        Task<APIResponseModel> AddDepartment(TblHospitalDeptModel deptModel);
        bool UpdateDepartment(int id);

        bool DeleteDepartment(int id);
        TblHospitalDeptModel GetDepartmentByID(int id);

        List<TblHospitalDeptModel> GetAllDepartment(string? searchBy = null);
    }
}
