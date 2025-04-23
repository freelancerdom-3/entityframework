using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.MenuPermissionModel.ViewModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblMenuRoleMapping;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblMenuPermission
{
    public class TblMenuPermission : ITblMenuPermission

    {
        private readonly HSMDBContext _hsmDbContext;
        public TblMenuPermission(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();

            // if (_tokenData.IsPermission((int)Enums.Roles.Patient, "IsView"))
            List<TblMenuRoleMapping> lstmenupermisson = new();

            if (true)
            {
                try
                {

                    using (var connection = _hsmDbContext)
                    {
                        lstmenupermisson = await connection.TblMenuRolemapping.FromSqlRaw($@"
select TMR.MenuRoleMappingID,TR.RoleName,TM.MenuName,
TMR.RoleID,TMR.MenuID,TMR.IsAdd,TMR.IsEdit,TMR.IsDelete,TMR.IsView,TMR.IsActive,
TU.FullName AS CreatedBy,UT.FullName AS UpdatedBy
 from TblMenuRoleMapping TMR
inner join TblUser TU ON TU.UserId = TMR.CreatedBy
left join TblUser UT ON UT.UserId = TMR.UpdatedBy
LEFT join TblMenu TM ON TM.MenuID = TMR.MenuID
inner join TblRole TR ON TR.RoleId = TMR.RoleID
where TU.FullName like '%{searchBy}%'").ToListAsync();
                        responseModel.Data = lstmenupermisson;
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

