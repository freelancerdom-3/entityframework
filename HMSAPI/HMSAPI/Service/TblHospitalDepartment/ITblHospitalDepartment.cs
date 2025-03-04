using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalDepartment;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.TblHospitalDept
{
    public interface ITblHospitalDepartment
    {

        //APIResponseModel
        Task<APIResponseModel> Add(TblHospitalDepartmentModel deptModel);
        Task <APIResponseModel> Update(TblHospitalDepartmentModel departmentModel);

        Task <APIResponseModel> Delete(int id);
        Task<APIResponseModel> GetByID(int id);

        Task<APIResponseModel> GetAll(string? searchBy = null);
    }
}
