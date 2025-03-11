using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Service.GetDropDownList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.GetDropDownList
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDropDownListController : ControllerBase
    {
        private readonly IGetDropDownList _getDropDownList;
        public GetDropDownListController(IGetDropDownList getDropDownList)
        {
            _getDropDownList = getDropDownList;
        }
  
        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillRoles()
        {
            return await _getDropDownList.FillRoles();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillShift()
        {
            return await _getDropDownList.FillShift();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillUserName()
        {
            return await _getDropDownList.FillUserName();
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillDepartmentname()
        {
            return await _getDropDownList.FillDepartmentname();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillDiseaseName()
        {
            return await _getDropDownList.FillDiseaseName();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillMedicineTypeName()
        {
            return await _getDropDownList.FillMedicineTypeName();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillRoomtype()
        {
            return await _getDropDownList.FillRoomtype();
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillFacilityName()
        {
            return await _getDropDownList.FillFacilityName();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillFacilityType()
        {
            return await _getDropDownList.FillFacilityType();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillPatientName()
        {
            return await _getDropDownList.FillPatientName();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillRoomNo()
        {
            return await _getDropDownList.FillRoomNo();
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillDocterName()
        {
            return await _getDropDownList.FillDocterName();
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> FillPaymentMethod()
        {
            return await _getDropDownList.FillPaymentMethod();
        }


    }
}
