using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Service.TblHospitalType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblHospitalType
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblHospitalTypeController : ControllerBase
    {
        private readonly ITblHospitalType _serviceTblHospitalType;

        public TblHospitalTypeController(ITblHospitalType tblHospital)
        {
            _serviceTblHospitalType = tblHospital;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblHospitalTypeModel hospitalTypModel)
        {
            return await _serviceTblHospitalType.Add(hospitalTypModel);
        }



        [HttpPatch("[action]")]
        public async Task<APIResponseModel> Update(TblHospitalTypeModel HospitalType)
        {
            return await _serviceTblHospitalType.Update(HospitalType);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int ID)
        {
            return await _serviceTblHospitalType.Delete(ID);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetById(int id)
        {
            return await _serviceTblHospitalType.GetById(id);
        }


        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblHospitalType.GetAll(searchBy);
        }
    }


}
