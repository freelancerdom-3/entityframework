using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRole;
using HMSAPI.Model.TblShift;
using HMSAPI.Service.TblShift;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblShift
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblShiftController : ControllerBase
    {

        private readonly ITblShift _serviceTblShift;

        public TblShiftController(ITblShift Shift)
        {

            _serviceTblShift = Shift;
        }


        


        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblShiftModel TblShiftModel)
        {
            return await (_serviceTblShift.Add(TblShiftModel));
        }


        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll()
        {
            return await(_serviceTblShift.GetAll());
        }


        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {

            return await(_serviceTblShift.Delete(id));
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblShiftModel model)
        {
            return await(_serviceTblShift.Update(model));
        }



        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetById(int id)
        {
            return await(_serviceTblShift.GetById(id));
        }



    }
}
