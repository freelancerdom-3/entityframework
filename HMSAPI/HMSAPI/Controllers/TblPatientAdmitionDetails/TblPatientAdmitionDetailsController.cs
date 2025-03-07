using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblPatientAdmitionDetails;
using HMSAPI.Model.TblRole;
using HMSAPI.Service.TblPatientAdmitionDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblPatientAdmitionDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPatientAdmitionDetailsController : ControllerBase
    {
        private readonly ITblPatientAdmitionDetails _serviceTblPatientAdmitionDetails;

        public TblPatientAdmitionDetailsController(ITblPatientAdmitionDetails tblPatientAdmitionDetails)
        {
            _serviceTblPatientAdmitionDetails=tblPatientAdmitionDetails;
        }


        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblPatientAdmitionDetailsModel Add)
        {
            return await _serviceTblPatientAdmitionDetails.Add(Add);
        }

        [HttpPatch("[action]")]
        public async Task<APIResponseModel> Update(TblPatientAdmitionDetailsModel UpdateId)
        {
            return await _serviceTblPatientAdmitionDetails.Update(UpdateId);
        }

        [HttpDelete("[action]")]

        public async Task<APIResponseModel> delete(int DeleteId)
        {
            return await _serviceTblPatientAdmitionDetails.delete(DeleteId);
        }
        [HttpGet("[action]")]

        public async Task<APIResponseModel> GetById(int id)
        {
            return await _serviceTblPatientAdmitionDetails.GetById(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblPatientAdmitionDetails.GetAll(searchBy);
        }

    }
}
