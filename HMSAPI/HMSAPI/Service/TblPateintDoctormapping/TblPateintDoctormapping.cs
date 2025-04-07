using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblPateintDoctormapping;
using HMSAPI.Model.TblPateintDoctormapping.ViewModel;
using HMSAPI.Model.TblTreatmentDetails.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblPateintDoctormapping
{
    public class TblPateintDoctormapping : ITblPateintDoctormapping
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblPateintDoctormapping(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }
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

                        data.UserId = departmentModel.UserId;
                        data.PatientId = departmentModel.PatientId;
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

                        connection.TblPateintDoctormappingModels.Remove(data);
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
        public async Task<APIResponseModel> Deletebyid(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblPateintDoctormappingModel? data = await connection.TblPateintDoctormappingModels.Where(x => x.TreatmentDetailsId == id).FirstOrDefaultAsync();

                    //delete
                    if (data != null)
                    {

                        connection.TblPateintDoctormappingModels.Remove(data);
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

            List<GetPateintDoctorMappingViewModel> lstUsers = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstUsers = await connection.GetPateintDoctorMappingViewModels.FromSqlRaw($@"SELECT tp.PateintDoctormappingId,tu.FullName as DocterName,pu.FullName as PatientName FROM TblPateintDoctormapping tp
                 inner join TblPatient Td on td.PatientId =tp.PatientId
                  inner join TblUser Tu on tu.UserId= tp.UserId
                  inner join TblUser pu  on pu.UserId=td.UserId
                      where  pu.FullName like '%{searchBy}%'").ToListAsync();

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
            TblPateintDoctormappingModel data = new();
            try
            {

                using (var connection = _hsmDbContext)
                {


                    data = await connection.TblPateintDoctormappingModels.Where(x => x.PateintDoctormappingId == id).FirstOrDefaultAsync();



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

