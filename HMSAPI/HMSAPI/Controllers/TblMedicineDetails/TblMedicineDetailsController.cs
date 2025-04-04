using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineDetails;
using HMSAPI.Service.TblMedicineDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblMedicineDetails
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblMedicineDetailsController : ControllerBase
    {
        private readonly ITblMedicineDetails _serviceTblMedicineDetails;
        public TblMedicineDetailsController(ITblMedicineDetails TblMedicineDetails)
        {
            _serviceTblMedicineDetails = TblMedicineDetails;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblMedicineDetailsModel model)
        {
            return await _serviceTblMedicineDetails.Add(model);
            }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblMedicineDetailsModel TblMedicineDetails)
        {
            return await _serviceTblMedicineDetails.Update(TblMedicineDetails);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int ID)
        {
            return await _serviceTblMedicineDetails.Delete(ID);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int ID)
        {
            return await _serviceTblMedicineDetails.GetByID(ID);
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchby = null)
        {
            return await _serviceTblMedicineDetails.GetAll(searchby);
        }
    }
}
