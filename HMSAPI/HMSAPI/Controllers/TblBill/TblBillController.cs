using HMSAPI.Model.EmailModel;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblBill;
using HMSAPI.Service.TblBill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblBill
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TblBillController : ControllerBase
    {
        private readonly ITblBill _serviceTblBill;
        public TblBillController(ITblBill tblBill)
        {
            _serviceTblBill = tblBill;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblBill.GetAll(searchBy);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int id)
        {
            return await _serviceTblBill.GetByID(id);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<APIResponseModel> Add(TblBillModel bill)
        {
            return await _serviceTblBill.Add(bill);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<APIResponseModel> Update(int id, TblBillModel bill)
        {
            return await _serviceTblBill.Update(id , bill);
        }

        [HttpDelete("[action]")]
        [AllowAnonymous]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _serviceTblBill.Delete(id);
        }
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> EmailBillPdfToPatient(EmailBillRequest request)
        {
            var pdfBytes = Convert.FromBase64String(request.PdfBase64);
            var result = await _serviceTblBill.EmailBillPdfToPatient(request.BillId, pdfBytes);

            return StatusCode((int)result.StatusCode, result);
        }




    }
}
