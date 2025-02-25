using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Service.TblDiseaseType;
//using HMSAPI.Service.TblUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblDiseaseType
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly ITblDiseaseType _serviceTblDiesaesType;
        public DiseaseController(ITblDiseaseType TblDiesaesType)
        {
            _serviceTblDiesaesType = TblDiesaesType;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll(string? searchBy = null)
        {
            return Ok(_serviceTblDiesaesType.GetAll(searchBy));
        }
        [HttpPost("[action]")]
        public IActionResult AddDiseases(TblDiseaseTypeModel typeModel)
        {
            return Ok(_serviceTblDiesaesType.AddDieases(typeModel));
        }
        [HttpDelete("action")]
        public IActionResult DeleteDisease(int id)
        {
            return Ok(_serviceTblDiesaesType.DeleteDieases(id));
        }

        [HttpPut("action")]
        public IActionResult UpdateDieases(int id)
        {
            return Ok(_serviceTblDiesaesType.UpdateDieasesWithID(id));
        }
        [HttpGet("action")]
        public IActionResult GetTblDieasesTypeById(int id)
        {
            return Ok(_serviceTblDiesaesType.GetTblDiseaseTypeById(id));
        }// GetTblDiseaseTypeById
    }
}
