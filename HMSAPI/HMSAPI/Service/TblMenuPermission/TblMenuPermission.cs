using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMenuRoleMapping;
using HMSAPI.Model.TblMenuRoleMapping.GetTblMenuPermissionViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblMenuPermission
{
    public class TblMenuPermission : ITblMenuPermission

    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;
        public TblMenuPermission(HSMDBContext hSMDBContext, ITokenData tokenData)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokenData;
        }
        private int UserId => Convert.ToInt32(_tokenData.UserID);

              
        public async Task<APIResponseModel> GetAll(int? roleId = null, string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            List<GetTblMenuPermissionViewModel> lstmenupermisson = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    
                    var query = @"
 SELECT 
     TMR.MenuRoleMappingID,   
     TR.RoleName,
TR.RoleID,
TMR.MenuID,
     TM.MenuName,
     TMR.IsAdd,
     TMR.IsEdit,
     TMR.IsDelete,
     TMR.IsView,
     TMR.IsActive,
     TU.FullName AS CreatedBy,
     UT.FullName AS UpdatedBy
 FROM TblMenuRoleMapping TMR
 INNER JOIN TblUser TU ON TU.UserId = TMR.CreatedBy
 LEFT JOIN TblUser UT ON UT.UserId = TMR.UpdatedBy
 LEFT JOIN TblMenu TM ON TM.MenuID = TMR.MenuID
 INNER JOIN TblRole TR ON TR.RoleId = TMR.RoleID
WHERE (@roleId IS NULL OR TMR.RoleID = @roleId)
AND (@searchBy IS NULL OR TU.FullName LIKE '%' + @searchBy + '%')";

                    lstmenupermisson = await connection.gettblmenupermissionviewmodel
                        .FromSqlRaw(query, new SqlParameter("@roleId", roleId ?? (object)DBNull.Value),
                                               new SqlParameter("@searchBy", searchBy ?? string.Empty))
                        .ToListAsync();

                    responseModel.Data = lstmenupermisson;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = null;
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException?.Message ?? ex.Message;
                responseModel.Data = null;
            }

            return responseModel;
        }


        public async Task<APIResponseModel> Add(List<TblMenuRoleMapping> newMappings)
        {
            APIResponseModel responseModel = new();

            int roleId = newMappings.First().RoleID;

            try
            {
                using (var connection = _hsmDbContext)
                {
                  
                    var existingMappings = await connection.TblMenuRolemapping .Where(x => x.RoleID ==  roleId).ToListAsync();
                    connection.TblMenuRolemapping.RemoveRange(existingMappings);

                  
                    foreach (var item in newMappings)
                    {
                       
                        item.CreatedBy = UserId;
                        item.IsActive = true;
                        item.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    await connection.TblMenuRolemapping.AddRangeAsync(newMappings);
                  
                    await connection.SaveChangesAsync();

                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Menu role mappings replaced successfully.";
                    responseModel.Data = true;
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException?.Message ?? ex.Message;
                responseModel.Data = false;
            }

            return responseModel;
        }
    }
}

