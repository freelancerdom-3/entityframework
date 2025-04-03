using HMSAPI.EFContext;
using HMSAPI.Model.Enums;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Service.TblHospitalType;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSAPI.Service.TblHospitalTyp
{
    public class TblHospitalType : ITblHospitalType
    {
        //private readonly HSMDBContext _hsmDbContext;


        //public TblHospitalType(HSMDBContext hSMDBContext)
        //{
        //    _hsmDbContext = hSMDBContext;
        //}

        private readonly HSMDBContext _hsmDbContext;

       

        private readonly ITokenData _tokenData;


        public TblHospitalType(HSMDBContext hSMDBContext)//, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
          //  _tokenData = tokendata;

        }

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
                        data.HospitalType = HospitalType.HospitalType;
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
                        lstHospitalType = connection.getTblHospitalTypeModels.FromSqlRaw($@"SELECT TU.FullName AS CreatedBy,UT.FullName
                         AS UpdatedBy,HT.HospitalTypeID,HT.HospitalType,HT.CreatedOn,HT.UpdateOn,HT.IsActive,HT.VersionNo
                         FROM TblHospitalType HT INNER JOIN TblUser TU ON TU.UserId=HT.CreateBy INNER JOIN TblUser UT 
                         ON UT.UserId=HT.UpdateBy where TU.FullName like '%{searchBy}%'").ToList();
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
