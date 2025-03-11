using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Model.TblFacilityTypes;
using HMSAPI.Service.TblDiseaseType;
using HMSAPI.Service.TblFacilityTypes;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSAPI.Service.TblFacilityTypes
{
    public class TblFacilityTypes : ITblFacilityTypes
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblFacilityTypes(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public async Task<APIResponseModel> Add(TblFacilityTypeModels tblFacilityType)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicatefacility = connection.TblFacilityTypes
                        .Any(x => x.FacilityName.ToLower() == tblFacilityType.FacilityName.ToLower());
                    if (!duplicatefacility)
                    {
                        tblFacilityType.VersionNo = 1;
                        _ = await connection.TblFacilityTypes.AddAsync(tblFacilityType);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Data = false;
                        responseModel.Message = "Duplicate Name Not Found";
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




        public async Task<APIResponseModel> Update(TblFacilityTypeModels tblFacilityType)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblFacilityTypeModels? data = await connection.TblFacilityTypes.Where(x => x.FacilityTypeID == tblFacilityType.FacilityTypeID).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.TblFacilityTypes.Update(data);
                        data.IncreamentVersion();
                        connection.SaveChanges();
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Facility Successfully:";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Facility AllReady Add";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.BadRequest;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = false;
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
                    TblFacilityTypeModels? data = await connection.TblFacilityTypes
                   .Where(x => x.FacilityTypeID == id)
                   .FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.TblFacilityTypes.Remove(data);
                        connection.SaveChanges();
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete SuccessFully:";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "FacilityType Not Found";
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



        public async Task<APIResponseModel> GetByID(int id)
        {
            APIResponseModel responseModel = new();
            TblFacilityTypeModels data = new TblFacilityTypeModels();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    data = await connection.TblFacilityTypes.Where(x => x.FacilityTypeID == id).FirstAsync();

                    if (data != null)
                    {
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Get Shaw Record SuccessFully";
                        responseModel.Data = data;
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Does Not Match A Data";
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

        public async Task<APIResponseModel> GetAll(string? searchby = null)
        {
            APIResponseModel responseModel = new();
            List<TblFacilityTypeModels> lstFacility = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstFacility = string.IsNullOrEmpty(searchby) ? await connection.TblFacilityTypes.ToListAsync() :
                        await connection.TblFacilityTypes.Where(x => x.FacilityName.ToLower() == searchby.ToLower()).ToListAsync();

                }
                if (lstFacility != null)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get All Recode Successfull";
                    responseModel.Data = lstFacility;

                }
                else
                {
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                    responseModel.Message = "Record Not Found";
                    responseModel.Data = null;
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