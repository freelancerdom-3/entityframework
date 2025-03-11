using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblPatientAdmitionDetails;
using HMSAPI.Model.TblPatientAdmitionDetails.ViewModel;
using HMSAPI.Model.TblRole;
using HMSAPI.Model.TblUser.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Cryptography;

namespace HMSAPI.Service.TblPatientAdmitionDetails
{
    public class TblPatientAdmitionDetails : ITblPatientAdmitionDetails
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblPatientAdmitionDetails (HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public async Task<APIResponseModel> Add(TblPatientAdmitionDetailsModel objadd)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    

                
                    bool duplicateRoleName = connection.tblPatientAdmitionDetails.Any(x => x.UserId == objadd.UserId && x.AdmisionDate.Date == objadd.AdmisionDate.Date);
                    if (duplicateRoleName)
                    {
                        
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Patient Already Exists";
                        responseModel.Data = false;
                    }
                    else
                    {
                        objadd.VersionNo = 1;
                        _ = connection.tblPatientAdmitionDetails.Add(objadd);
                        
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
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

        public async Task<APIResponseModel> delete(int objDelete)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {

                    TblPatientAdmitionDetailsModel? data = connection.tblPatientAdmitionDetails.Where(x => x.PatientAdmitionDetailsId == objDelete).FirstOrDefault();
                    if (data != null)
                    {
                        connection.tblPatientAdmitionDetails.Remove(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";

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
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        
        }

        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            List<GetTblPatientAdmitionDetailsViewModel> lstPatientAdmitionDetails = new();
            try
            {

                

                using (var connection = _hsmDbContext)
                {

                    lstPatientAdmitionDetails = await connection.GetTblPatientAdmitionDetailsViewModel.FromSql($@"select TblPatientAdmitionDetails.PatientAdmitionDetailsId,TblRoom.RoomNumber,TblUser.fullname  from TblPatientAdmitionDetails
                             inner join TblUser on TblUser.UserId = TblPatientAdmitionDetails.UserID 
                    inner join TblRoom on TblRoom.RoomId = TblPatientAdmitionDetails.RoomId where fullname like '%{searchBy}%'").ToListAsync();

                    responseModel.Data = lstPatientAdmitionDetails;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Your Data";
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

        public async Task<APIResponseModel> GetById(int objGetById)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblPatientAdmitionDetailsModel? data = connection.tblPatientAdmitionDetails.
                     Where(x => x.PatientAdmitionDetailsId == objGetById).FirstOrDefault();
                    responseModel.Data = new
                    {
                        data.PatientAdmitionDetailsId,
                        data.UserId,
                        data.AdmisionDate,
                        data.RoomID,
                        data.TreatmentDetailsId,
                        data.DischargeDate,
                    };
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Your Information";

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

        public async Task<APIResponseModel> Update(TblPatientAdmitionDetailsModel ObjUpdate)
        {
            APIResponseModel responseModel = new();

           

            try
            {

                using (var connection = _hsmDbContext)
                {

                    TblPatientAdmitionDetailsModel? data = connection.tblPatientAdmitionDetails.Where(x => x.PatientAdmitionDetailsId == ObjUpdate.PatientAdmitionDetailsId).FirstOrDefault();

                    if (data != null)
                    {
                        data.UserId= ObjUpdate.UserId;
                        data.AdmisionDate= ObjUpdate.AdmisionDate;
                        data.RoomID= ObjUpdate.RoomID;
                        data.TreatmentDetailsId= ObjUpdate.TreatmentDetailsId;
                        data.DischargeDate= ObjUpdate.DischargeDate;
                        data.UpdateBy  = ObjUpdate.UpdateBy;
                        data.UpdateOn = ObjUpdate.UpdateOn;
                        data.IsActive = ObjUpdate.IsActive;
                        data.IncreamentVersion();
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Enter Valied Id";
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
