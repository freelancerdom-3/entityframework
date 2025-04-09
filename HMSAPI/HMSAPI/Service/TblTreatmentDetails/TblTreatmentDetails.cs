using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblTreatmentDetails;
using HMSAPI.Model.TblTreatmentDetails.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblTreatmentDetails
{
    public class TblTreatmentDetails : ITblTreatmentDetails
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblTreatmentDetails(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }
        public async Task<APIResponseModel> Add(TblTreatmentDetailsModel deptModel)
        {

            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {

                    //bool duplicateUserId = connection.TblTreatmentDetails
                    //    .Any(x => x.PatientId == deptModel.PatientId);

                    //if (!duplicateUserId)
                    //{
                        //#1
                        deptModel.VersionNo = 1;
                        
                        _ = await connection.TblTreatmentDetails.AddAsync(deptModel);
                        connection.SaveChanges();
                        //#3
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
                    //}
                    //else
                    //{
                    //    responseModel.StatusCode = HttpStatusCode.BadRequest;
                    //    responseModel.Message = "Duplicate Id Found";
                    //    responseModel.Data = false;
                    //}
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
        public async Task<APIResponseModel> Update(TblTreatmentDetailsModel departmentModel)
        {
            APIResponseModel responseModel = new();
            try
            {

                using (var connection = _hsmDbContext)
                {
                    TblTreatmentDetailsModel? data = await connection.TblTreatmentDetails.Where(x => x.TreatmentDetailsId == departmentModel.TreatmentDetailsId).FirstOrDefaultAsync();

                    //update
                    if (data != null)
                    {

                        data.DieseaseTypeID = departmentModel.TreatmentDetailsId;
                        data.PatientId = departmentModel.TreatmentDetailsId;
                        data.TreatmentDate=departmentModel.TreatmentDate;
                        data.UpdatedBy = departmentModel.UpdatedBy;
                        data.UpdatedOn = departmentModel.UpdatedOn;
                        data.IsActive = departmentModel.IsActive;
                        data.IncreamentVersion();
                        connection.TblTreatmentDetails.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Updated Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Department ID Not Found";
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

        public async Task<APIResponseModel> Delete(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblTreatmentDetailsModel? data = await connection.TblTreatmentDetails.Where(x => x.TreatmentDetailsId == id).FirstOrDefaultAsync();

                    //delete
                    if (data != null)
                    {

                        connection.TblTreatmentDetails.Remove(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Deleted Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Department ID Not Found";
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

        public async Task<APIResponseModel> Deletebyid(HSMDBContext context, int id)
        {
            APIResponseModel responseModel = new();
            try
            {
               // using (var connection = _hsmDbContext)
                {
                    TblTreatmentDetailsModel? data = await context.TblTreatmentDetails.Where(x => x.PatientId == id).FirstOrDefaultAsync();

                    //delete
                    if (data != null)
                    {

                        context.TblTreatmentDetails.Remove(data);
                        context.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Deleted Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Department ID Not Found";
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
        public async  Task<APIResponseModel> GetByID(int id)
        {
            APIResponseModel responseModel = new();
            TblTreatmentDetailsModel data = new();
            try
            {

                using (var connection = _hsmDbContext)
                {


                    data = await connection.TblTreatmentDetails.Where(x => x.TreatmentDetailsId == id).FirstOrDefaultAsync();



                    if (data != null)
                    {


                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Get Record Successfully";
                        responseModel.Data = data;

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Department ID Not Found";
                        responseModel.Data = null;

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

            List<GetTblTreatmentDetailsViewModel> lstUsers = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstUsers = await connection.GetTblTreatmentDetailsViewModel.FromSqlRaw($@"SELECT tt.TreatmentDetailsId,td.DieseaseName,tuser.FullName FROM TblTreatmentDetails tt
                     inner join TblDiseaseType Td on td.DieseaseTypeID = tt.DieseaseTypeID
                     inner join TblPatient tp on tp.PatientId = tt.PatientId
                     inner join TblUser tuser on tuser.UserId = tp.UserId where FullName like '%{searchBy}%'").ToListAsync();
                    responseModel.Data = lstUsers;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get Record Successfully";
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
