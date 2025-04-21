using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblPateintDoctormapping;
using HMSAPI.Model.TblPateintDoctormapping.ViewModel;
using HMSAPI.Model.TblTreatmentDetails.ViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblPateintDoctormapping
{
    public class TblPateintDoctormapping : ITblPateintDoctormapping
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;

        public TblPateintDoctormapping(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;
        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);

        public async Task<APIResponseModel> Add(TblPateintDoctormappingModel deptModel)
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
                    deptModel.CreatedBy = UserId;
                    deptModel.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    deptModel.VersionNo = 1;
                    _ = await connection.TblPateintDoctormappingModels.AddAsync(deptModel);
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
        public async Task<APIResponseModel> Update(TblPateintDoctormappingModel departmentModel)
        {
            APIResponseModel responseModel = new();
            try
            {

                using (var connection = _hsmDbContext)
                {
                    TblPateintDoctormappingModel? data = await connection.TblPateintDoctormappingModels.Where(x => x.PateintDoctormappingId == departmentModel.PateintDoctormappingId).FirstOrDefaultAsync();

                    //update
                    if (data != null)
                    {
                        departmentModel.UpdatedBy = UserId;
                        departmentModel.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        data.UserId = departmentModel.UserId;
                        //data.PatientId = departmentModel.PatientId;
                        data.TreatmentDetailsId = departmentModel.TreatmentDetailsId;
                        data.UpdatedBy = departmentModel.UpdatedBy;
                        data.UpdatedOn = departmentModel.UpdatedOn;
                        data.IsActive = departmentModel.IsActive;
                        data.IncreamentVersion();
                        connection.TblPateintDoctormappingModels.Update(data);
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
                    TblPateintDoctormappingModel? data = await connection.TblPateintDoctormappingModels.Where(x => x.PateintDoctormappingId == id).FirstOrDefaultAsync();

                    //delete
                    if (data != null)
                    {
                        data.IsActive = false;
                        connection.TblPateintDoctormappingModels.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Deleted Successfully";

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
        
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();

            List<GetPatientMappingViewModel> lstUsers = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstUsers = await connection.getPatientMappingViewModels.FromSqlRaw($@"select tp.PateintDoctormappingId,tuu.FullName as DocterName,tu.FullName as PatientName,
                    tt.TreatmentDetailsId,us.FullName as CreatedBy,tp.CreatedOn,pr.FullName as UpdatedBy,tp.UpdatedOn,
                    tp.IsActive,tp.VersionNo
                    from TblPateintDoctormapping tp 
                    inner join TblUser us on us.UserId = tp.CreatedBy
                    left join TblUser pr on pr.UserId = tp.UpdatedBy
                    inner join TblTreatmentDetails tt on tt.TreatmentDetailsId = tp.TreatmentDetailsId
                    inner join TblPatient tpa on tpa.PatientId = tt.PatientId
                    inner join TblUser tu on tu.UserId = tpa.UserId
                    inner join TblUser tuu on tuu.UserId = tp.UserId
                    and us.IsActive = 1
                    and tt.IsActive = 1
                    where tp.IsActive = 1
                    and  tuu.FullName like '%{searchBy}%'").ToListAsync();
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

        public async Task<APIResponseModel> GetByID(int id)
        {
            APIResponseModel responseModel = new();
            TblPateintDoctormappingModel? data = new();
            try
            {

                using (var connection = _hsmDbContext)
                {


                    data = await connection.TblPateintDoctormappingModels.Where(x => x.PateintDoctormappingId == id && x.IsActive == true).FirstOrDefaultAsync();



                    if (data != null)
                    {


                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Get Record Successfully";
                        responseModel.Data = data;

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID Not Found";
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
    }




}

