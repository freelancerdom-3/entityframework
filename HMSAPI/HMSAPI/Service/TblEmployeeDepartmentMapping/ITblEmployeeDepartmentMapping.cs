using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblEmployeeDepartmentMapping;


namespace HMSAPI.Service.TblEmployeeDepartmentMapping
{
    public interface ITblEmployeeDepartmentMapping
    {
        Task<APIResponseModel> Add(TblEmployeeDepartmentMappingModel deptModel);
        Task<APIResponseModel> Update(TblEmployeeDepartmentMappingModel departmentModel);

        Task<APIResponseModel> Delete(int id);
        Task<APIResponseModel> GetByID(int id);

        Task<APIResponseModel> GetAll(string? searchBy = null);
    }
}
