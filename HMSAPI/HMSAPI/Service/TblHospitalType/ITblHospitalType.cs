using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;

namespace HMSAPI.Service.TblHospitalType
{
    public interface ITblHospitalType
    {
        Task<APIResponseModel> Add(TblHospitalTypeModel HospitalType);

        Task<APIResponseModel> Update(TblHospitalTypeModel HospitalType);
            
        Task<APIResponseModel> Delete(int id);

        Task<APIResponseModel> GetById(int id);

        Task<APIResponseModel> GetAll(string? searchBy = null);
    }
}
