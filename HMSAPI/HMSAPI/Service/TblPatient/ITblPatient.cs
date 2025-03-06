using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;

namespace HMSAPI.Service.TblPatient
{
    public interface ITblPatient
    {
        
        Task<APIResponseModel> Delete(int id);
    }
}
