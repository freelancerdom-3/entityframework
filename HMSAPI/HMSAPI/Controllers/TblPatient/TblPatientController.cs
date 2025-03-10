using HMSAPI.Model.GenericModel;
using HMSAPI.Service.TblHospitalType;
using HMSAPI.Service.TblPatient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HMSAPI.Model.TblPatient;
using HMSAPI.Model.TblPatient.ViewModel;

namespace HMSAPI.Controllers.TblPatient
{
    [Route("api/[controller]")]
    [ApiController]
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


        [HttpPost("[action]")] 
        public async Task<APIResponseModel> Update(GetTblPatientViewModel update )
        {
            return await _serviceTblPatient.Update(update);
        }


        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblPatient.GetAll(searchBy);
        }

        //[HttpGet("[action]")]
        //public async Task<APIResponseModel> GetByID(int id)
        //{
        //    return await _serviceTblPatient.GetByID(id);
        //}

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int UserId)
        {
            //return await _serviceTblPatient.Delete(model);
            //return await _serviceTblPatient.Delete(model);
            return await _serviceTblPatient.Delete(UserId);
        }
    }

}
