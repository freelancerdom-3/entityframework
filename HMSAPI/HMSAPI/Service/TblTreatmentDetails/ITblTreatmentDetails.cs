using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblEmployeeDepartmentMapping;
using HMSAPI.Model.TblTreatmentDetails;

namespace HMSAPI.Service.TblTreatmentDetails
{
    public interface ITblTreatmentDetails
    {
        Task<APIResponseModel> Add(TblTreatmentDetailsModel deptModel);
        Task<APIResponseModel> Update(TblTreatmentDetailsModel departmentModel);

        Task<APIResponseModel> Delete(int id);
        Task<APIResponseModel> GetByID(int id);

        Task<APIResponseModel> GetAll(string? searchBy = null);

        Task<APIResponseModel> Deletebyid(int id);

        Task<APIResponseModel> DeletebyDiseaseTypeID(HSMDBContext connection, int id);
    }
}
