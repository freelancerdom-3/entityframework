using HMSAPI.Model.GenericModel;

namespace HMSAPI.Service.GetDropDownList
{
    public interface IGetDropDownList
    {
        Task<APIResponseModel> FillRoles();

        Task<APIResponseModel> FillShift();

        Task <APIResponseModel>FillUserName ();

        Task <APIResponseModel> FillDepartmentname ();
        
        Task <APIResponseModel>FillDiseaseName ();

        Task <APIResponseModel> FillMedicineTypeName ();
        Task<APIResponseModel> FillRoomtype();
        Task<APIResponseModel> FillFacilityName();

         Task<APIResponseModel> FillFacilityType();

        Task<APIResponseModel> FillPatientName();

        Task<APIResponseModel> FillRoomNo();

        Task<APIResponseModel> FillDocterName();

        Task <APIResponseModel>FillPaymentMethod ();
    }
}
