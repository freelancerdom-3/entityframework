using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.TblUser
{
    public interface ITblUser
    {
        List<TblUserModel> GetAll(string? searchBy=null);
        bool validateCredential(string email,string password);
        TblUserModel? validateCredentialWithData(string email,string password);

        bool SignupUser(TblUserModel userModel);
        bool ForgetPassword(string email);


    }
}
