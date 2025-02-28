using HMSAPI.Model.TblHospitalDep;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.TblHospitalDept
{
    public interface ITblHospitalDept
    {
        bool AddDepartment(TblHospitalDeptModel deptModel);
        bool UpdateDepartment(int id);

        bool DeleteDepartment(int id);
        TblHospitalDeptModel GetDepartmentByID(int id);

        List<TblHospitalDeptModel> GetAllDepartment(string? searchBy = null);
    }
}
