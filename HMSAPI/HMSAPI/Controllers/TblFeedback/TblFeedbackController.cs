using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFeedback;
using HMSAPI.Service.TblFeedback;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblFeedback
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblFeedbackController : ControllerBase
    {
        private readonly ITblFeedback _serviceTblFeedback;


        public TblFeedbackController(ITblFeedback tblFeedback)
        {
            _serviceTblFeedback = tblFeedback;
        }

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblFeedbackModel Feedbackmodel)
        {
            return await _serviceTblFeedback.Add(Feedbackmodel);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _serviceTblFeedback.Delete(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblFeedback.GetAll(searchBy);
        }

    }
}
