using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Service.TblDiseaseType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblDiseaseType
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DiseaseController : ControllerBase
    {
        private readonly ITblDiseaseType _serviceTblDiesaesType;
        public DiseaseController(ITblDiseaseType TblDiesaesType)
        {
            _serviceTblDiesaesType = TblDiesaesType;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblDiseaseTypeModel DiseasetypeModel)
        {

            return await _serviceTblDiesaesType.Add(DiseasetypeModel);
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblDiseaseTypeModel model)
        {
            return await _serviceTblDiesaesType.Update(model);
        }

       [HttpDelete("[action]")]
        public async Task<APIResponseModel> deleteByID(int id)
        {
            return await _serviceTblDiesaesType.deleteByID(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int id)
        {
            return await _serviceTblDiesaesType.GetByID(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblDiesaesType.GetAll(searchBy);
        }

    }
}
