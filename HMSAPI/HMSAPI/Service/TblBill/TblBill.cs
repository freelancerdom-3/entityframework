using System.Net;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblBill;
using HMSAPI.Model.TblBill.ViewModel;
using HMSAPI.Model.TblMedicineType;
using HMSAPI.Model.TblUser;
using HMSAPI.Model.TblUser.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.Service.TblBill
{
    public class TblBill : ITblBill
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblBill(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            try
            {
                List<BillPatientViewModel> lstbills = new();
                using (var connection = _hsmDbContext)
                {
                    lstbills = await connection.billPatientViewModels.FromSqlRaw($@"
                     SELECT   b.Billid,   u.FullName, b.TotalAmount,  b.PaymentMethod, b.BillDate
                     FROM TblBill b
                     INNER JOIN TblPatient p ON b.PatientId = p.PatientId
                     INNER JOIN TblUser u ON p.UserId = u.UserId where FullName like '%{searchBy}%'").ToListAsync();
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
                     SELECT   b.Billid,   u.FullName, b.TotalAmount,  b.PaymentMethod, b.BillDate
                     FROM TblBill b
                     INNER JOIN TblPatient p ON b.PatientId = p.PatientId
                     INNER JOIN TblUser u ON p.UserId = u.UserId where Billid like '%{id}%'").ToListAsync();
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
                    bool duplicatetreatment = connection.TblBills
                       .Any(x => x.TreatmentDetailsId == bill.TreatmentDetailsId);

                    if (!duplicatetreatment)
                    {
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
                       // data.BillId = bill.BillId;
                        data.BillDate = bill.BillDate;
                        data.TotalAmount = bill.TotalAmount;
                        data.PaymentMethod = bill.PaymentMethod;
                        data.PatientId = bill.PatientId;
                        data.TreatmentDetailsId = bill.TreatmentDetailsId;
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
                        connection.TblBills.Remove(data);
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

    }
}
