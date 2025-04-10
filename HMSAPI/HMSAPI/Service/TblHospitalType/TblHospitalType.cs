using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Service.TblHospitalType;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblHospitalTyp
{
    public class TblHospitalType : ITblHospitalType
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;
        public TblHospitalType(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;

        }

        //private int UserId => Convert.ToInt32(_tokenData.UserID);
        //private int RoleId => Convert.ToInt32(_tokenData.RoleId);
        private int UserID => Convert.ToInt32(_tokenData.UserID);

        public async Task<APIResponseModel> Add(TblHospitalTypeModel hospitalTypModel)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicateName = connection.TblHospitalTypes
                    .Any(x => x.HospitalType.ToLower() == hospitalTypModel.HospitalType.ToLower());

                    if (!duplicateName)
                    {
                        hospitalTypModel.VersionNo = 1;
                        //_hsmDbContext.TblHospitalTypes.Add(hospitalTypModel);

                        //_hsmDbContext.SaveChanges();
                        hospitalTypModel.IsActive = true;
                        hospitalTypModel.UpdatedBy = '0';
                        

                        hospitalTypModel.CreatedBy = UserID;
                        hospitalTypModel.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        hospitalTypModel.CreatedOn = DateTime.Now;
                        _ = await connection.TblHospitalTypes.AddAsync(hospitalTypModel);
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


        public async Task<APIResponseModel> Update(TblHospitalTypeModel HospitalType)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblHospitalTypeModel? data =  await  connection.TblHospitalTypes.Where(x => x.HospitalTypeID == HospitalType.HospitalTypeID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        //HospitalType.UpdatedBy = Convert.ToInt32(_tokenData.UserID);
                        HospitalType.UpdatedOn =Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                        HospitalType.UpdatedBy = UserID;
                        data.HospitalType = HospitalType.HospitalType;
                        data.UpdatedOn = HospitalType.UpdatedOn;
                        connection.TblHospitalTypes.Update(data);
                        data.IncreamentVersion();
                        connection.SaveChanges();
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
    


        public async Task<APIResponseModel> Delete(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblHospitalTypeModel? data = await connection.TblHospitalTypes.Where(x => x.HospitalTypeID == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.TblHospitalTypes.Remove(data);
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


        public async Task<APIResponseModel> GetById(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblHospitalTypeModel data =  await connection.TblHospitalTypes.Where(x => x.HospitalTypeID == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = data.HospitalType;
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



        public async Task<APIResponseModel>  GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();

            // if (_tokenData.IsPermission((int)Enums.Roles.Patient, "IsView"))
            List<GetTblHospitalTypeModel> lstHospitalType = new();

            if (true)
            {
                try
                {
                    
                    using (var connection = _hsmDbContext)
                    {
                        lstHospitalType = connection.getTblHospitalTypeModels.FromSqlRaw($@"SELECT 
    TU.FullName AS CreatedBy,
	UT.FullName AS UpdatedBy,
		HT.HospitalTypeID,
		HT.HospitalType,
		HT.CreatedOn,
		HT.UpdatedOn,
		HT.IsActive,
		HT.VersionNo
FROM TblHospitalType HT 
	 INNER JOIN TblUser TU ON TU.UserId=HT.CreatedBy 
	 LEFT JOIN TblUser UT ON UT.UserId=HT.UpdatedBy where TU.FullName like '%{searchBy}%'").ToList();
                        responseModel.Data = lstHospitalType;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = null;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = HttpStatusCode.InternalServerError;
                    responseModel.Message = ex.InnerException.Message;
                    responseModel.Data = null;
                }
            }
            else
            {
                responseModel.Message = "you dont have permission";
            }
               
            return responseModel;
        }
    }
}
