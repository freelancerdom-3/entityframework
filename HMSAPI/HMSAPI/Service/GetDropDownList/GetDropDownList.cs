using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Model.TblFacility;
using HMSAPI.Model.TblFacilityTypes;
using HMSAPI.Model.TblHospitalDepartment;
using HMSAPI.Model.TblMedicineType;
using HMSAPI.Model.TblRole;
using HMSAPI.Model.TblShift;
using HMSAPI.Model.TblUser;
using Microsoft.AspNetCore.Mvc;
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

                    //responseModel.Data = lstRolles;
                    responseModel.Data = lstRolles.Select(x => new GetDropDownListModel() { id = x.RoleId, name = x.RoleName }).ToList(); 

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

                    //responseModel.Data = lstRolles;
                    responseModel.Data = lstRolles.Select(x => new GetDropDownListModel() { id = x.ShiftId, name = x.Shiftname}).ToList();

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

                    //responseModel.Data = lstRolles;
                    responseModel.Data = lstRolles.Select(x => new GetDropDownListModel() { id = x.UserId, name = x.FullName }).ToList();

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
                    lstRolles = connection.TblHospitalDepts.ToList();

                    //responseModel.Data = lstRolles;
                    responseModel.Data = lstRolles.Select(x => new GetDropDownListModel() { id = x.HospitalDepartmentId, name = x.DepartmentName}).ToList();

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

                    //responseModel.Data = lstRolles;
                    responseModel.Data = lstRolles.Select(x => new GetDropDownListModel() { id = x.DieseaseTypeID, name = x.DieseaseName }).ToList();

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

                    //responseModel.Data = lstRolles;
                    responseModel.Data = lstRolles.Select(x => new GetDropDownListModel() { id = x.MedicineTypeID, name = x.TypeName }).ToList();

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

                    //responseModel.Data = lstRolles;
                    responseModel.Data = lstRolles.Select(x => new GetDropDownListModel() { id = x.RoomTypeId, name = x.RoomType}).ToList();

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

                    //responseModel.Data = lstRolles;
                    responseModel.Data = lstRolles.Select(x => new GetDropDownListModel() { id = x.FacilityID, name = x.FacilityName }).ToList();

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

                    //responseModel.Data = lstRolles;
                    responseModel.Data = lstRolles.Select(x => new GetDropDownListModel() { id = x.FacilityTypeID, name = x.FacilityName }).ToList();

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
