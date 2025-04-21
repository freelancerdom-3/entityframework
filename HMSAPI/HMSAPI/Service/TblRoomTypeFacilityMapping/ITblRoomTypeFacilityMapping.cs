using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRoomTypeFacilityMapping;

namespace HMSAPI.Service.TblRoomTypeFacilityMapping
{
    public interface ITblRoomTypeFacilityMapping
    {
        Task<APIResponseModel> Add(TblRoomTypeFacilityMappingModel facilitymodel);

        Task<APIResponseModel> Update(TblRoomTypeFacilityMappingModel facilitymodel);

        Task<APIResponseModel> Delete(int id);


        Task<APIResponseModel> GetById(int id);


        Task<APIResponseModel> GetAll(string? searchBy = null);

       
    }
}
