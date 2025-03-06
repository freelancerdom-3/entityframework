using HMSAPI.Model.GenericModel;
using HMSAPI.Service.TblHospitalType;
using HMSAPI.Service.TblPatient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HMSAPI.Model.TblPatient;

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


        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
           return await _serviceTblPatient.Delete(id);
        }
    }

}
