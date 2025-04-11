using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineDetails;
using HMSAPI.Model.TblMedicineDetails.ViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblMedicineDetails
{
    public class TblMedicineDetails : ITblMedicineDetails
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;
        public TblMedicineDetails(HSMDBContext hsmDbContext, ITokenData tokenData)
        {
            _hsmDbContext = hsmDbContext;
            _tokenData=tokenData;
        }
        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);
        public async Task<APIResponseModel> Add(TblMedicineDetailsModel model)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    connection.Database.BeginTransaction();
                    bool DuplicateTreatmentID = connection.TblMedicineDetails.Any(x => x.TreatmentDetailsId == model.TreatmentDetailsId);
                    // && x.IssueDateTime >= model.IssueDateTime.AddSeconds(-10) &&
                       // x.IssueDateTime <= model.IssueDateTime.AddSeconds(10));
                    try
                    {
                        if (!DuplicateTreatmentID)
                        {
                            model.VersionNo = 1;
                            model.CreatedBy = UserId;
                            model.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); 
                            model.IssueDateTime= DateTime.Now;
                            
                            _ = await connection.TblMedicineDetails.AddAsync(model);
                            connection.SaveChanges();
                            connection.Database.CommitTransaction();
                            responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                            responseModel.Data = true;
                            responseModel.Message = "Record Inserted Sucessfully";
                        }
                        else
                        {
                            connection.Database.RollbackTransaction();
                            responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                            responseModel.Message = "You Enter data is Duplicate";
                            responseModel.Data = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        connection.Database.RollbackTransaction();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {

                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> Update(TblMedicineDetailsModel TblMedicineDetails)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblMedicineDetailsModel? data = await connection.TblMedicineDetails
                        .Where(x => x.MedicineDetailsID == TblMedicineDetails.MedicineDetailsID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        data.MedicineTypeID = TblMedicineDetails.MedicineTypeID;
                        data.Dosage = TblMedicineDetails.Dosage;
                        data.Frequency = TblMedicineDetails.Frequency;
                        data.Duration = TblMedicineDetails.Duration;
                        data.Instruction = TblMedicineDetails.Instruction;
                        data.UpdatedBy = UserId;
                        data.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); ;
                        data.IsActive = TblMedicineDetails.IsActive;
                        data.IncreamentVersion();
                        connection.Update(data);
                        connection.SaveChanges();
                        responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                        responseModel.Data = true;
                        responseModel.Message = "Record Updated Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        responseModel.Data = false;
                        responseModel.Message = "Not Updated";
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
        public async Task<APIResponseModel> Delete(int ID)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                using(var connection = _hsmDbContext)
                {
                    TblMedicineDetailsModel? data = await connection.TblMedicineDetails
                        .Where(x => x.MedicineDetailsID == ID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.TblMedicineDetails.Remove(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                        responseModel.Message = "Deleted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        responseModel.Message = "Delete Not successfully";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
        public async Task<APIResponseModel> Deletebyid(HSMDBContext context, int ID)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                //using (var connection = _hsmDbContext)
                {
                    TblMedicineDetailsModel? data = await context.TblMedicineDetails
                        .Where(x => x.TreatmentDetailsId == ID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        context.TblMedicineDetails.Remove(data);
                        context.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                        responseModel.Message = "Deleted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        responseModel.Message = "Delete Not successfully";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
        public async Task<APIResponseModel> GetByID(int ID)
        {
            APIResponseModel responseModel = new();
            TblMedicineDetailsModel? data = new TblMedicineDetailsModel();
            try
            {
                using(var connection = _hsmDbContext)
                {
                    data = await connection.TblMedicineDetails.Where(x => x.MedicineDetailsID == ID).FirstOrDefaultAsync();
                    responseModel.Data = data;
                    responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> GetAll(string? searchby = null)
        {
            APIResponseModel responseModel = new APIResponseModel();
            List<GetMedicineDetailsViewModel> lstMedicineDetails = new List<GetMedicineDetailsViewModel>();
            try
            {
                using(var connection = _hsmDbContext)
                {
                    lstMedicineDetails = await connection.GetMedicineDetailsViewModel.FromSqlRaw($@"select TblMe.MedicineDetailsID,TMedi.TypeName,TDies.DieseaseName,
                   TblMe.Dosage,TblMe.Frequency,TblMe.Duration,TblMe.Instruction,TblMe.IssueDateTime,tu.FullName as CreatedBy,TblMe.CreatedOn,
            TblUser.FullName as UpdatedBy,TblMe.UpdatedOn,TblMe.IsActive,TblMe.VersionNo from TblMedicineDetails TblMe
              inner join TblUser tu on tu.UserId = TblMe.CreatedBy
            left join TblUser on TblUser.UserId = TblMe.UpdatedBy
           inner join TblMedicineType TMedi on TMedi.MedicineTypeID = TblMe.MedicineTypeID
                 inner join TblTreatmentDetails on TblTreatmentDetails.TreatmentDetailsId = TblMe.TreatmentDetailsId
            inner join TblDiseaseType TDies on TDies.DieseaseTypeID = TblTreatmentDetails.DieseaseTypeID where TypeName like '%{searchby}%'")
                                         .ToListAsync();
                    responseModel.Data = lstMedicineDetails;
                    responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responseModel.Message = "GetAll Record Successfully";
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public  async Task<APIResponseModel> DeletebyMedicineTypeID(HSMDBContext connection, int id)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                 List<TblMedicineDetailsModel> medicineid = connection.TblMedicineDetails.Where(x => x.MedicineTypeID == id).ToList();

                if (medicineid != null)
                {
                    foreach (TblMedicineDetailsModel medicine in medicineid)
                    {
                        connection.TblMedicineDetails.Remove(medicine);
                    }
                }
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Deleted Successfully";
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
