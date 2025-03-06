using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Model.TblUser;
using Microsoft.EntityFrameworkCore;


using HMSAPI.Service.TblUser;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSAPI.Service.TblDiseaseType
{
    public class TblDiseaseType : ITblDiseaseType
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblDiseaseType(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        // ADD DIEASES 

        public async Task<APIResponseModel> Add(TblDiseaseTypeModel tblDiseaseType)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool DuplicateDieases = connection.tblDiseaseTypes
                        .Any(x => x.DieseaseName.ToLower() == tblDiseaseType.DieseaseName.ToLower());
                    if (!DuplicateDieases)
                    {
                        _ = await connection.tblDiseaseTypes.AddAsync(tblDiseaseType);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate Name Found:";
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

        public async Task<APIResponseModel> Update(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblDiseaseTypeModel? data = await connection.tblDiseaseTypes.Where(x => x.DieseaseTypeID == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.tblDiseaseTypes.Update(data);
                        connection.SaveChanges();
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Dieases Successfully:";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Dieases AllReady Add";
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

        //Delete
        public async Task<APIResponseModel> delete(TblDiseaseTypeModel tblDiseaseType)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblDiseaseTypeModel? data = await connection.tblDiseaseTypes
                   .Where(x => x.DieseaseName.ToLower() == tblDiseaseType.DieseaseName.ToLower())
                   .FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.tblDiseaseTypes.Remove(data);
                        connection.SaveChanges();
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete SuccessFully:";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "DieasesName Is Not Found";
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

        //DELETEBYID
        public async Task<APIResponseModel> deleteByID(int id)

        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblDiseaseTypeModel? data = await connection.tblDiseaseTypes
                   .Where(x => x.DieseaseTypeID == id)
                   .FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.tblDiseaseTypes.Remove(data);
                        connection.SaveChanges();
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete SuccessFully:";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "DieasesName Is Not Found";
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
        

        //GETTBL
        public async Task<APIResponseModel> GetTbl(int id)
        {
            APIResponseModel responseModel = new();
            TblDiseaseTypeModel data = new TblDiseaseTypeModel();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    data = await connection.tblDiseaseTypes.Where(x => x.DieseaseTypeID == id).FirstAsync();

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

        //GETALL
        public async Task<APIResponseModel> GetAll(string? searchby = null)
        {
            APIResponseModel responseModel = new();
            List<TblDiseaseTypeModel> lstDisease = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstDisease = string.IsNullOrEmpty(searchby) ? await connection.tblDiseaseTypes.ToListAsync() :
                        await connection.tblDiseaseTypes.Where(x => x.DieseaseName.ToLower() == searchby.ToLower()).ToListAsync();

                }
                if (lstDisease != null)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get All Recode Successfull";
                    responseModel.Data = lstDisease;

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
