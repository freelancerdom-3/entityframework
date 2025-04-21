using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblBill;
using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Model.TblFacility;
using HMSAPI.Model.TblFacilityTypes;
using HMSAPI.Model.TblHospitalDepartment;
using HMSAPI.Model.TblMedicineType;
using HMSAPI.Model.TblRole;
using HMSAPI.Model.TblRoom;
using HMSAPI.Model.TblShift;
using HMSAPI.Model.TblTreatmentDetails;
using HMSAPI.Model.TblUser;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.GetDropDownList
{
    public class GetDropDownList : IGetDropDownList
    {
        private readonly HSMDBContext _hsmDbContext;
        public GetDropDownList(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public async Task<APIResponseModel> FillRoles()
        {
             APIResponseModel responseModel = new();

             List<TblRoleModel> lstRolles = new();
             List<GetDropDownListModel> lstRolles1 = new();

             try
             {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.TblRoles.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true). Select(x => new GetDropDownListModel() { id = x.RoleId, name = x.RoleName }).ToList(); 
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get list Successfully";
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
        public async Task<APIResponseModel> FillShift()
        {
            APIResponseModel responseModel = new();

            List<TblShiftModel> lstRolles = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.TblShifts.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true).Select(x => new GetDropDownListModel() { id = x.ShiftId, name = x.Shiftname}).ToList();
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillUserName()
        {
            APIResponseModel responseModel = new();

            List <TblUserModel> lstRolles = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.TblUsers.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true).Select(x => new GetDropDownListModel() { id = x.UserId, name = x.FullName }).ToList();
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillDepartmentname()
        {
            APIResponseModel responseModel = new();

            List<TblHospitalDepartmentModel> lstRolles = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.TbLHospitalDepartment.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true).Select(x => new GetDropDownListModel() { id = x.HospitalDepartmentId, name = x.DepartmentName}).ToList();
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillDiseaseName()
        {
            APIResponseModel responseModel = new();

            List<TblDiseaseTypeModel> lstRolles = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.TblDiseaseType.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true).Select(x => new GetDropDownListModel() { id = x.DieseaseTypeID, name = x.DieseaseName }).ToList();
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillMedicineTypeName()
        {
            APIResponseModel responseModel = new();

            List<TblMedicineTypeModel> lstRolles = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.TblMedicineTypes.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true).Select(x => new GetDropDownListModel() { id = x.MedicineTypeID, name = x.TypeName }).ToList();
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillRoomtype()
        {
            APIResponseModel responseModel = new();

            List<TblRoomTypeModel> lstRolles = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.tblRoomTypes.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true).Select(x => new GetDropDownListModel() { id = x.RoomTypeId, name = x.RoomType}).ToList();
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillFacilityName()
        {
            APIResponseModel responseModel = new();

            List<TblFacilityModel> lstRolles = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.TblFacility.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true).Select(x => new GetDropDownListModel() { id = x.FacilityID, name = x.FacilityName }).ToList();
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillFacilityType()
        {
            APIResponseModel responseModel = new();

            List<TblFacilityTypeModels> lstRolles = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.TblFacilityTypes.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true).Select(x => new GetDropDownListModel() { id = x.FacilityTypeID, name = x.FacilityName }).ToList();
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillPatientName()
        {
            APIResponseModel responseModel = new ();

         
        List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                      string query = $@" select tp.PatientId as id,tu.FullName as [name] from TblUser tu
                                    inner join  TblPatient tp on tp.UserId = tu.UserId  
									where RoleId = 2 and tp.IsActive =1 and  tu.IsActive =1";
                   lstRolles1  = await connection.GetDropDownListModel.FromSqlRaw(query).ToListAsync();
                    responseModel.Data = lstRolles1;
                     responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillRoomNo()
        {
            APIResponseModel responseModel = new();

            List<TblRoomModel> lstRolles = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.TblRoom.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true).Select(x => new GetDropDownListModel() { id = x.RoomID, name = x.RoomNumber.ToString() }).ToList();
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillDocterName()
        {
            APIResponseModel responseModel = new();


            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    string query = $@"select UserId as id, FullName as name from TblUser where RoleId != 2";                                                                                   
                    lstRolles1 = await connection.GetDropDownListModel.FromSqlRaw(query).ToListAsync();
                    responseModel.Data = lstRolles1;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillPaymentMethod()
        {
            APIResponseModel responseModel = new();

            List<TblBillModel> lstRolles = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.TblBills.ToList();
                    responseModel.Data = lstRolles.Where(x => x.IsActive == true).Select(x => new GetDropDownListModel() { id = x.BillId, name = x.PaymentMethod }).ToList();
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
        public async Task<APIResponseModel> FillTreatmentCode()
        {
            APIResponseModel responseModel = new();

            List<TblTreatmentDetailsModel> lsttreatmentdetails = new();
            List<GetDropDownListModel> lstRolles1 = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    string query = $@"select td.TreatmentDetailsId as id,concat(td.TreatmentDetailsId,'-',u.FullName) as name 
                    from TblTreatmentDetails td
                    inner join TblPatient p on td.PatientId=p.PatientId
                     inner join TblUser u on u.UserId=p.UserId   WHERE td.TreatmentDetailsId NOT IN (
                    SELECT treatmentDetailsId FROM TblPatientAdmitionDetails
                )";
                    lstRolles1 = await connection.GetDropDownListModel.FromSqlRaw(query).ToListAsync();
                    responseModel.Data = lstRolles1;

                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get List Successfully";
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
