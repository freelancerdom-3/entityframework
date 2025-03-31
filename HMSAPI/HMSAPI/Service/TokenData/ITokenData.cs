using HMSAPI.Model.Enums;
using static HMSAPI.Model.Enums.Enums;

namespace HMSAPI.Service.TokenData
{
    public interface ITokenData 
    {
        public long UserID { get; }

        public long RoleId {  get; }

        public bool IsPermission(Menus menuId, PermissionType permissionType);

    }
}
