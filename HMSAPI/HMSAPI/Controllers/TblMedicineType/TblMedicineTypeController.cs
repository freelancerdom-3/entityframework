using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineType;
using HMSAPI.Service.TblMedicineType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblMedicineType
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblMedicineTypeController : ControllerBase
    {
        private readonly ITblMedicineType _serviceTblMedicineTyp;
        public TblMedicineTypeController(ITblMedicineType tblMedicineTyp)
        {
            _serviceTblMedicineTyp = tblMedicineTyp;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblMedicineTypeModel medicineModel)
        {
            return await _serviceTblMedicineTyp.Add(medicineModel);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int id)
        {
            return await _serviceTblMedicineTyp.GetByID(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblMedicineTyp.GetAll(searchBy);
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblMedicineTypeModel model)
        {
            return await _serviceTblMedicineTyp.Update(model);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int Id)
        {
            return await _serviceTblMedicineTyp.Delete(Id);
        }
    }
}
