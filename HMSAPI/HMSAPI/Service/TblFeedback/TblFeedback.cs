using System.Net;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFeedback;
using HMSAPI.Model.TblHospitalType;
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

        public async Task<APIResponseModel> Update(TblFeedbackModel Feedbackmodel)
        {
            APIResponseModel responseModel = new();
            try
            {
                using(var connection = _hsmDbContext)
                {
                    TblFeedbackModel? Data = await connection.TblFeedbacks.Where(x => x.PatientId == Feedbackmodel.PatientId).FirstOrDefaultAsync();
                    if(Data != null)
                    {
                        connection.TblFeedbacks.Update(Data);
                        connection.SaveChangesAsync();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Successfully";
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

        public async Task<APIResponseModel> GetById(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblFeedbackModel data = await connection.TblFeedbacks.Where(x => x.PatientId == id).FirstOrDefaultAsync();
                    if(data != null)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = data.Comments;
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Id Not Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode= HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            } 
            return responseModel;
        }


        //public async Task<APIResponseModel> GetAll(string? searchBy = null)
        //{
        //    APIResponseModel aPIResponseModel = new();
        //    try
        //    {
        //        List<TblFeedbackModel> lstFeedback = new();
        //        using (var connection = _hsmDbContext)
        //        {
        //            lstFeedback = string.IsNullOrEmpty(searchBy) ? connection.TblFeedbacks.ToList() :
        //                connection.TblFeedbacks.Where(x => x.PatientId == searchBy).ToList();

        //        }
        //    }
        //}

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
                        connection.TblFeedbacks.Remove(data);
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

        //public async Task<APIResponseModel> Delete(int id)
        //{
        //    APIResponseModel responseModel = new APIResponseModel();
        //    try
        //    {
        //        TblFeedbackModel? data = await _hsmDbContext.TblFeedbacks
        //            .Where(x => x.FeedbackId == id)
        //            .FirstOrDefaultAsync();

        //        if (data != null)
        //        {
        //            _hsmDbContext.TblFeedbacks.Remove(data); // ✅ Correct table deletion
        //            await _hsmDbContext.SaveChangesAsync(); // ✅ Ensure async save

        //            responseModel.Data = true;
        //            responseModel.StatusCode = HttpStatusCode.OK;
        //            responseModel.Message = "Deleted Successfully";
        //        }
        //        else
        //        {
        //            responseModel.StatusCode = HttpStatusCode.BadRequest;
        //            responseModel.Message = "ID Not Found";
        //            responseModel.Data = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        responseModel.StatusCode = HttpStatusCode.InternalServerError;
        //        responseModel.Message = ex.InnerException?.Message ?? ex.Message; // ✅ Avoid null reference exception
        //        responseModel.Data = null;
        //    }

        //    return responseModel;
        //}


    }
}
