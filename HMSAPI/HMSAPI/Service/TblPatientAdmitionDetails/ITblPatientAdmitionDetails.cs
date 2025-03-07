using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblPatientAdmitionDetails;
using HMSAPI.Model.TblRole;

namespace HMSAPI.Service.TblPatientAdmitionDetails
{
    public interface ITblPatientAdmitionDetails
    {
        Task<APIResponseModel> Add(TblPatientAdmitionDetailsModel objadd);

        Task<APIResponseModel> Update(TblPatientAdmitionDetailsModel ObjUpdate);

        Task<APIResponseModel> delete(int objDelete);

        Task<APIResponseModel> GetById(int objGetById);

        Task<APIResponseModel> GetAll(string? searchBy = null);
    }
}
