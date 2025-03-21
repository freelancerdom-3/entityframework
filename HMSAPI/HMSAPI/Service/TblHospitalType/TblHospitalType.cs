﻿using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Service.TblHospitalType;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSAPI.Service.TblHospitalTyp
{
    public class TblHospitalType : ITblHospitalType
    {
        private readonly HSMDBContext _hsmDbContext;


        public TblHospitalType(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
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
            try
            {
                List<TblHospitalTypeModel> lstHospitalType = new();
                using (var connection = _hsmDbContext)
                {
                    lstHospitalType = string.IsNullOrEmpty(searchBy) ? connection.TblHospitalTypes.ToList() :
                    connection.TblHospitalTypes.Where(x => x.HospitalType.ToLower() == searchBy.ToLower()).ToList();
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
            return responseModel;
        }
    }
}
