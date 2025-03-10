using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblPatient;
using HMSAPI.Model.TblPatient.ViewModel;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.TblPatient
{
    public interface ITblPatient
    {
        Task<APIResponseModel> Add(GetTblPatientViewModel patient);
        
        Task<APIResponseModel> Delete(int  UserId);
        Task<APIResponseModel> Update(GetTblPatientViewModel update);

        Task<APIResponseModel> GetAll(string? searchBy = null);
        //Task<APIResponseModel> GetByID(int id);
    }
}
