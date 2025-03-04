using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineDiseaseMapping;
using HMSAPI.Service.TblMedicineDiseaseMapping;
using HMSAPI.Service.TblMedicineType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblMedicineDiseaseMapping
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblMedicineDiseaseMappingController : ControllerBase
    {
        private readonly ITblMedicineDiseaseMapping _serviceTblMedicineDieseaseMapping;
        public TblMedicineDiseaseMappingController(ITblMedicineDiseaseMapping TblMedicineDiseaseMapping)
        {
            _serviceTblMedicineDieseaseMapping = TblMedicineDiseaseMapping;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblMedicineDiseaseMappingModel model)
        {
            return await _serviceTblMedicineDieseaseMapping.Add(model);
        }

        [HttpPatch("[action]")]
        public async Task<APIResponseModel> Update(TblMedicineDiseaseMappingModel MedicineDiseaseMapping)
        {
            return await _serviceTblMedicineDieseaseMapping.Update(MedicineDiseaseMapping);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchby = null)
        {
            return await _serviceTblMedicineDieseaseMapping.GetAll(searchby);
        }

        [HttpGet("[action]")]

        public async Task<APIResponseModel> GetByID(int ID)
        {
            return await _serviceTblMedicineDieseaseMapping.GetByID(ID);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> DeleteByID(int Id)
        {
            return await _serviceTblMedicineDieseaseMapping.DeleteByID(Id);
        }

    }
}
