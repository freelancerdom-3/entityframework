using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.TblUser
{
    public interface ITblUser
    {
        Task<APIResponseModel> GetAll(string? searchBy = null);
        Task<APIResponseModel> validateCredential(string email, string password);
        Task<APIResponseModel> validateCredentialWithData(string email, string password);

        Task<APIResponseModel> SignupUser(TblUserModel userModel);
        Task<APIResponseModel> ForgetPassword(string email);

        Task<APIResponseModel> MobileNumber();

        //Task<APIResponseModel> AddRoleId(string roleId);
        Task<APIResponseModel> AddRoleId(int userId);
    }
}
