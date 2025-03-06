
﻿using HMSAPI.Model.TblUser;
using HMSAPI.Model.TblUser.ViewModel;
﻿using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblUser;
using HMSAPI.Model.TblPatient;
using HMSAPI.Model.TblPatient.ViewModel;
namespace HMSAPI.Service.TblUser
{
    public interface ITblUser
    {

        Task<APIResponseModel>  GetAll(string? searchBy=null);
  
        Task<APIResponseModel> ValidateCredential(string email,string password);
        //Task<APIResponseModel> validateCredentialWithData(string email,string password);

        Task<APIResponseModel> SignupUser(TblUserModel userModel);
        Task<APIResponseModel> ForgetPassword(string email);

        //Task<APIResponseModel> AddRoleId(string roleId);
        Task<APIResponseModel> Add(GetTblPatientViewModel model);

        Task<APIResponseModel> Update(TblUserModel model);

        Task<APIResponseModel> Delete(int id);
    }
}
