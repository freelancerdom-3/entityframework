﻿using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblBill;

namespace HMSAPI.Service.TblBill
{
    public interface ITblBill
    {
        Task<APIResponseModel> GetAll(string? searchBy = null);
        Task<APIResponseModel> GetByID(int id);
        Task<APIResponseModel> Add(TblBillModel bill);
        Task<APIResponseModel> Update(int id, TblBillModel bill);
        Task<APIResponseModel> Delete(int id);
        Task<APIResponseModel> Deletebyid(HSMDBContext context, int id);
        Task<APIResponseModel> EmailBillPdfToPatient(int billId ,byte[] pdfBytes);

        //Task<APIResponseModel> GetTotalEarnings(string? searchBy = null);
        Task<APIResponseModel> GetTotalEarningsByDate();
        Task<APIResponseModel> GetTotalEarningsWeek (string? searchBy = null);
    }
}
