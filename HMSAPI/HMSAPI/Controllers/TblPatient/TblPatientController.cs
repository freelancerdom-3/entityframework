using HMSAPI.Model.GenericModel;
using HMSAPI.Service.TblPatient;
using Microsoft.AspNetCore.Mvc;
using HMSAPI.Model.TblPatient.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace HMSAPI.Controllers.TblPatient
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblPatientController : ControllerBase
    {
        private readonly ITblPatient _serviceTblPatient;
        

        public TblPatientController(ITblPatient tblPatient)
        {
            _serviceTblPatient = tblPatient;
        }



        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(GetTblPatientViewModel patient)
        {
            return await _serviceTblPatient.Add(patient);
        }


        [HttpPut("[action]")] 
        public async Task<APIResponseModel> Update(GetTblPatientViewModel update )
        {
            return await _serviceTblPatient.Update(update);
        }


        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblPatient.GetAll(searchBy);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetById(int id)
        {
            return await _serviceTblPatient.GetById(id);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int UserId)
        {
           return await _serviceTblPatient.Delete(UserId);
        }
    }

}
