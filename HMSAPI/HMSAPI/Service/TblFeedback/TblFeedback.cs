using System.Net;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFeedback;
using HMSAPI.Model.TblFeedback.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.Service.TblFeedback
{
    public class TblFeedback : ITblFeedback
    {
        private readonly HSMDBContext _hsmDbContext;


        public TblFeedback(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public async Task<APIResponseModel> Add(TblFeedbackModel Feedbackmodel)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicateId = connection.TblFeedbacks.Any(x => x.FeedbackId == Feedbackmodel.FeedbackId);

                    if(!duplicateId)
                    {
                        Feedbackmodel.VersionNo = 1;
                        _ = await connection.TblFeedbacks.AddAsync(Feedbackmodel);
                        connection.SaveChanges();
                        
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate Name Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }


        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            try
            {
                List<GetTblFeedbackViewModel> lstUsers = new();
                using ( var connection = _hsmDbContext)
                {
                    lstUsers = await connection.GetTblFeedbackViewModel.FromSqlRaw($@"
                    SELECT 
    f.FeedbackId,
    u.FullName AS FullName,
    f.Comments,
    f.Rating,
    f.FeedbackDate,
    f.TreatmentDetailsId,
    f.CreatedBy,
    f.CreatedOn,
    f.UpdatedBy,
    f.UpdatedOn,
    f.IsActive,
    f.VersionNo
FROM TblFeedback f
INNER JOIN TblTreatmentDetails td ON td.TreatmentDetailsId = f.TreatmentDetailsId
INNER JOIN TblPatient p ON p.PatientId = td.PatientId
INNER JOIN TblUser u ON u.UserId = p.UserId

").ToListAsync();
                    responseModel.Data = lstUsers;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Successfully";
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
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
                    TblFeedbackModel? data = await connection.TblFeedbacks.Where(x => x.FeedbackId == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        data.IsActive = false;
                        connection.TblFeedbacks.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID Not Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
        public async Task<APIResponseModel> Deletebyid( HSMDBContext context, int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                //using (var connection = _hsmDbContext)
                {
                    TblFeedbackModel? data = await context.TblFeedbacks.Where(x => x.TreatmentDetailsId == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        context.TblFeedbacks.Remove(data);
                        context.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID Not Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }


    }
}
