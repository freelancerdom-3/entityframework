using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblPatientAdmitionDetails;
using HMSAPI.Model.TblPatientAdmitionDetails.ViewModel;
using HMSAPI.Model.TblRole;
using HMSAPI.Model.TblRoom;
using HMSAPI.Model.TblUser.ViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Cryptography;

namespace HMSAPI.Service.TblPatientAdmitionDetails
{
    public class TblPatientAdmitionDetails : ITblPatientAdmitionDetails
    {
        private readonly HSMDBContext _hsmDbContext;

        private readonly ITokenData _tokenData;
        public TblPatientAdmitionDetails (HSMDBContext hSMDBContext , ITokenData tokenData)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokenData;
        }
        private int UserId => Convert.ToInt32(_tokenData.UserID);
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
                        objadd.CreatedBy = UserId;
                        objadd.CreatedOn= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

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
        public async Task<APIResponseModel> deletebyid(HSMDBContext context, int objDelete)
        {
            APIResponseModel responseModel = new();
            try
            {
                //using (var connection = _hsmDbContext)
                {

                    TblPatientAdmitionDetailsModel? data = context.tblPatientAdmitionDetails.Where(x => x.TreatmentDetailsId == objDelete).FirstOrDefault();
                    if (data != null)
                    {
                        context.tblPatientAdmitionDetails.Remove(data);
                        context.SaveChanges();
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

        public async Task<APIResponseModel> Deletebyroomid(HSMDBContext context,int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                //using (var connection = _hsmDbContext)
                //{
                //TblPatientAdmitionDetailsModel patientAdmission = await context.tblPatientAdmitionDetails.FindAsync(id);
                //List<TblRoomModel> roomid = context.TblRoom.Where(x => x.RoomTypeID == id).ToList();
                List<TblPatientAdmitionDetailsModel> patientAdmission = context.tblPatientAdmitionDetails.Where(x => x.RoomID == id).ToList();


                if (patientAdmission != null)
                    {
                    foreach(TblPatientAdmitionDetailsModel room in patientAdmission)
                    {
                    context.tblPatientAdmitionDetails.Remove(room);

                    }
                        await context.SaveChangesAsync();
                }
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Deleted Successfully";
                //}
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException?.Message ?? ex.Message;
                responseModel.Data = null;
            }

            return responseModel;
        }



        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            List<GetTblPatientAdmitionViewModel> lstPatientAdmitionDetails = new();
            try
            {

                

                using (var connection = _hsmDbContext)
                {
                    lstPatientAdmitionDetails = await connection.getTblPatientAdmition.FromSqlRaw($@"
                    
                    
select tp.PatientAdmitionDetailsId,tu.FullName as PatientName,tp.AdmisionDate,tr.RoomNumber,
tt.TreatmentCode,tp.DischargeDate,tk.FullName as CreatedBy,tp.CreatedOn,TblUser.FullName as UpdatedBy,
tp.UpdatedOn,tp.IsActive,tp.VersionNo from TblPatientAdmitionDetails tp
inner join TblUser tk on tk.UserId = tp.CreatedBy
left join TblUser on TblUser.UserId = tp.UpdatedBy
inner join TblTreatmentDetails tt on tt.TreatmentDetailsId = tp.TreatmentDetailsId
inner join TblRoom tr on tr.RoomID = tp.RoomID
inner join TblUser tu on tu.UserId = tp.UserId
                    where tu.FullName like '%{searchBy}%'").ToListAsync();
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
                        ObjUpdate.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ObjUpdate.UpdatedBy = UserId;

                        data.UserId= ObjUpdate.UserId;
                        data.AdmisionDate= ObjUpdate.AdmisionDate;
                        data.RoomID= ObjUpdate.RoomID;
                        data.TreatmentDetailsId= ObjUpdate.TreatmentDetailsId;
                        data.DischargeDate = ObjUpdate.DischargeDate;

                        data.UpdatedBy = ObjUpdate.UpdatedBy;

                        data.UpdatedOn = ObjUpdate.UpdatedOn;
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
