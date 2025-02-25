using HMSAPI.Model.TblMedicineType;
using HMSAPI.Service.TblMedicineType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblMedicineType
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblMedicineTypeController : ControllerBase
    {
        private readonly ITblMedicineType _serviceTblMedicineTyp;
        public TblMedicineTypeController(ITblMedicineType tblMedicineTyp)
        {
            _serviceTblMedicineTyp = tblMedicineTyp;
        }

        [HttpPost("[action]")]
        public IActionResult AddMedicine(TblMedicineTypeModel TypeName)
        {
            return Ok(_serviceTblMedicineTyp.AddMedicine(TypeName));
        }

        [HttpGet("[action]")]
        public IActionResult GetOnlyOneByID(int id)
        {
            return Ok(_serviceTblMedicineTyp.GetOnlyOneByID(id));
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_serviceTblMedicineTyp.GetAll());
        }

        [HttpPatch("[action]")]
        public IActionResult UpdateByID(int Id)
        {
            return Ok(_serviceTblMedicineTyp.UpdateByID(Id));
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteById(int Id)
        {
            return Ok(_serviceTblMedicineTyp.DeleteByID(Id));
        }
    }
}
