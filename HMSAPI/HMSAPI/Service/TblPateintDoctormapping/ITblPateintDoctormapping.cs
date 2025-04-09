using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblPateintDoctormapping;
using HMSAPI.Model.TblTreatmentDetails;

namespace HMSAPI.Service.TblPateintDoctormapping
{
    public interface ITblPateintDoctormapping
    {
        Task<APIResponseModel> Add(TblPateintDoctormappingModel deptModel);
        Task<APIResponseModel> Update(TblPateintDoctormappingModel departmentModel);

        Task<APIResponseModel> Delete(int id);
        Task<APIResponseModel> GetByID(int id);

        Task<APIResponseModel> GetAll(string? searchBy = null);

        Task<APIResponseModel> Deletebyid(HSMDBContext context, int id);  
        }
}
