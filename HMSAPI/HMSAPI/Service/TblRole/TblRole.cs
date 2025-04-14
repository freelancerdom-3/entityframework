using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRole;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblRole
{
    public class TblRole : ITblRole
        
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;
        public TblRole(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;
        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        public async Task<APIResponseModel> Add(TblRoleModel roleModel)
        {
            APIResponseModel responseModel = new();
            try 
            {
                using (var connection = _hsmDbContext)
                {


                    bool duplicateRoleName = connection.TblRoles.Any(x => x.RoleName.ToLower() == roleModel.RoleName.ToLower());
                    if (!duplicateRoleName)
                    {
                        roleModel.VersionNo = 1;
                        roleModel.CreatedBy = UserId;
                        roleModel.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        _ = connection.TblRoles.Add(roleModel);
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
        public async Task<APIResponseModel> delete(int id)
        {
            APIResponseModel responseModel = new();
            try 
            {
                using (var connection = _hsmDbContext)
                {
                    
                    TblRoleModel? data = connection.TblRoles.Where(x => x.RoleId == id).FirstOrDefault();
                    if (data != null)
                    {
                        connection.TblRoles.Remove(data);
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

        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();

            List<GetTblRoleViewModel> lstRolles = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = connection.getTblRoleViewModels.FromSqlRaw($@"
                   SELECT tu.FullName AS CreatedBy, uu.FullName AS UpdatedBy, tr.RoleId, 
                    tr.RoleName,tr.CreatedOn,tr.UpdatedOn, tr.IsActive,tr.VersionNo
                    FROM TblRole tr INNER JOIN TblUser tu ON tu.UserId = tr.CreatedBy 
                    left JOIN TblUser uu ON uu.UserId = tr.UpdatedBy 
                    where tu.fullName LIKE  '%{searchBy}%'").ToList();
                    //lstRolles = string.IsNullOrEmpty(searchBy) ? connection.TblRoles.ToList() : connection.TblRoles.Where(x => x.RoleName.ToLower() == searchBy.ToLower()).ToList();
                    responseModel.Data = lstRolles;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Inserted Successfully";
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

        public async Task<APIResponseModel> GetById (int id)
        {
            APIResponseModel responseModel = new();
            try 
            {
                using (var connection = _hsmDbContext)
                {
                    TblRoleModel? data = connection.TblRoles.
                     Where(x => x.RoleId == id).FirstOrDefault();
                    responseModel.Data = data.RoleName;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Inserted Successfully";

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

        public async Task <APIResponseModel>  Update(TblRoleModel roleModel)
        {
            APIResponseModel responseModel = new();

            try
            {

                using (var connection = _hsmDbContext)
                {

                    TblRoleModel? data = connection.TblRoles.Where(x => x.RoleId == roleModel.RoleId).FirstOrDefault();

                    if (data != null)
                    {
                        data.RoleName = data.RoleName;
                        data.UpdatedBy = data.UpdatedBy;
                        data.UpdatedOn = data.UpdatedOn;
                        data.IsActive = data.IsActive;
                        data.IncreamentVersion();
                        connection.TblRoles.Update(data);
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


    }
}
