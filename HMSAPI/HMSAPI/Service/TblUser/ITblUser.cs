using HMSAPI.Model.TblUser;
using HMSAPI.Model.TblUser.ViewModel;

namespace HMSAPI.Service.TblUser
{
    public interface ITblUser
    {
        List<GetTblUserViewModel> GetAll(string? searchBy=null);
        bool validateCredential(string email,string password);
        TblUserModel? validateCredentialWithData(string email,string password);

        bool SignupUser(TblUserModel userModel);
        bool ForgetPassword(string email);


    }
}
