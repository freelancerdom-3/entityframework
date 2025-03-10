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

        [HttpPost("[action]")]
        public async Task<APIResponseModel> Update(TblFeedbackModel FeedbackModel)
        {
            return await _serviceTblFeedback.Update(FeedbackModel);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GeyById(int id)
        {
            return await _serviceTblFeedback.GetById(id);
        }

        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _serviceTblFeedback.Delete(id);
        }

        //[HttpGet("[action]")]
        //public async Task<APIResponseModel>GetAll(string? searchBy = null)
        //{
        //    return await _serviceTblFeedback.GetAll(searchBy);
        //}

    }
}
