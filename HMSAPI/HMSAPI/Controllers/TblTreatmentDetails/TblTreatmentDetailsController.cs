using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblTreatmentDetails;
using HMSAPI.Service.TblTreatmentDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblTreatmentDetails
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblTreatmentDetailsController : ControllerBase
    {
        private readonly ITblTreatmentDetails _servicetblTreatmentDetails;
        public TblTreatmentDetailsController(ITblTreatmentDetails tblTreatmentDetails)
        {
            _servicetblTreatmentDetails = tblTreatmentDetails;
        }
        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblTreatmentDetailsModel DeptModel)
        {
            return await _servicetblTreatmentDetails.Add(DeptModel);
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblTreatmentDetailsModel departmentModel)
        {
            return await _servicetblTreatmentDetails.Update(departmentModel);
        }
        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _servicetblTreatmentDetails.Delete(id);
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int id)
        {
            return await _servicetblTreatmentDetails.GetByID(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _servicetblTreatmentDetails.GetAll(searchBy);
        }
    }
}
