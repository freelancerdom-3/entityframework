using System.Net;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblBill;
using HMSAPI.Model.TblBill.ViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.Service.TblBill
{
    public class TblBill : ITblBill
    {
        private readonly HSMDBContext _hsmDbContext;

        private readonly HttpContextAccessor _contextAccessor;

        private readonly ITokenData _tokenData;


        public TblBill(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;

        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            try
            {
                List<BillPatientViewModel> lstbills = new();
                using (var connection = _hsmDbContext)
                {
                    lstbills = await connection.billPatientViewModels.FromSqlRaw($@"
                    select tb.BillId,tu.FullName as PatientName,tb.TotalAmount,tb.PaymentMethod,tb.BillDate,tb.TreatmentDetailsId,
  us.FullName as CreatedBy,tb.CreatedOn,pr.FullName as UpdatedBy,tb.UpdatedOn,tb.IsActive,tb.VersionNo from TblBill tb 
 inner join TblUser us on us.UserId = tb.CreatedBy
left join TblUser pr on pr.UserId = tb.UpdatedBy
 inner join TblTreatmentDetails tt on tt.TreatmentDetailsId = tb.TreatmentDetailsId
 inner join TblPatient tp on tp.PatientId = tt.PatientId
 inner join TblUser tu on tu.UserId = tp.UserId where Tb.IsActive = 1 and tu.FullName like '%{searchBy}%'").ToListAsync();
                    responseModel.Data = lstbills;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Successfully";
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex?.InnerException?.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
        public async Task<APIResponseModel> GetByID(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                List<BillPatientViewModel> lstbills = new();
                using (var connection = _hsmDbContext)
                {
                    lstbills = await connection.billPatientViewModels.FromSql($@"
                   SELECT b.Billid, u.FullName, b.TotalAmount, b.PaymentMethod, b.BillDate
                FROM TblBill b
           INNER JOIN TblPatient p ON b.PatientId = p.PatientId
            INNER JOIN TblUser u ON p.UserId = u.UserId
            where b.IsActive = 1  and b.BillId = {id}")
                    .ToListAsync();
                    responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responseModel.Message = "Get All Record Successfully";
                    responseModel.Data = lstbills;
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex?.InnerException?.Message;
                responseModel.Data = null;
            }
            return responseModel;

        }
        public async Task<APIResponseModel> Add(TblBillModel bill)
        {
            APIResponseModel responseModel = new();
            try
            {
                
                using (var connection = _hsmDbContext)
                {
                    bill.VersionNo = 1;
                    bool duplicatetreatment = connection.TblBills
                       .Any(x => x.TreatmentDetailsId == bill.TreatmentDetailsId);

                    if (!duplicatetreatment)
                    {
                        bill.CreatedBy = UserId;
                        bill.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        _ = await connection.TblBills.AddAsync(bill);
                        
                        connection.SaveChanges();

                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate User Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex?.InnerException?.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
        public async Task<APIResponseModel> Update(int id, TblBillModel bill)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblBillModel? data = await connection.TblBills.Where(x => x.BillId == bill.BillId).FirstOrDefaultAsync();
                    if (data != null)

                    {
                        bill.UpdatedBy = UserId;
                        bill.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        data.BillDate = bill.BillDate;
                        data.TotalAmount = bill.TotalAmount;
                        data.PaymentMethod = bill.PaymentMethod;
                       // data.PatientId = bill.PatientId;
                        data.TreatmentDetailsId = bill.TreatmentDetailsId;
                        data.UpdatedBy = bill.UpdatedBy;
                        data.UpdatedOn = bill.UpdatedOn;
                        data.IncreamentVersion();
                        connection.TblBills.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate  Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex?.InnerException?.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> Delete(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblBillModel? data = await connection.TblBills.Where(x => x.BillId == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        data.IsActive = false;
                        connection.TblBills.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID  Not Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex?.InnerException? .Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
        public async Task<APIResponseModel> Deletebyid(HSMDBContext context, int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                //var connection = _hsmDbContext)
                {
                    TblBillModel? data = await context.TblBills.Where(x => x.TreatmentDetailsId == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        data.IsActive = false;
                        context.TblBills.Update(data);
                        context.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID  Not Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex?.InnerException?.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
    }
}
