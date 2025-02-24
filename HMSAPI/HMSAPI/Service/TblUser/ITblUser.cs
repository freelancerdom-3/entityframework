using HMSAPI.Model.TblUser;

namespace HMSAPI.Service.TblUser
{
    public interface ITblUser
    {
        List<TblUserModel> GetAll();
        bool validateCredential(string email,string password);
        TblUserModel? validateCredentialWithData(string email,string password);
    }
}
