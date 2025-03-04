using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblUser;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HMSAPI.Service.TblUser
{
    public class TblUser : ITblUser
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblUser(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public bool ForgetPassword(string email)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                TblUserModel? data = connection.TblUsers
                                  .Where(x => x.Email.ToLower() == email.ToLower()).
                                  FirstOrDefault();
                //update
                if (data != null)
                {
                    data.Password = "ABC@123";
                    connection.TblUsers.Update(data);
                    connection.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;

        }

        public List<TblUserModel> GetAll(string? searchBy = null)
        {
            List<TblUserModel> lstUsers = new();
            using (var connection = _hsmDbContext)
            {
                lstUsers = string.IsNullOrEmpty(searchBy) ? connection.TblUsers.ToList() :
                    connection.TblUsers.Where(x => x.FullName.ToLower() == searchBy.ToLower()).
                    ToList();
            }
            return lstUsers;
        }

        public bool SignupUser(TblUserModel userModel)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                //#2 only email should return
                //List<string> lstEmail = connection.TblUsers.Select(X=>X.Email).ToList();
                //#4
                //bool duplicateEmail = lstEmail.Any(x => x.ToLower() == userModel.Email.ToLower());

                //bool duplicateEmail =   connection.TblUsers.Where(x => x.Email.ToLower() == userModel.Email.ToLower()).
                //    FirstOrDefault()?.Email != null;

                bool duplicateEmail = connection.TblUsers
                    .Any(x => x.Email.ToLower() == userModel.Email.ToLower());


                if (!duplicateEmail)
                {
                    //#1
                    _ = connection.TblUsers.Add(userModel);
                    connection.SaveChanges();
                    //#3
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;

        }



        public bool validateCredential(string email, string password)
        {
            bool match = false;
            using (var connection = _hsmDbContext)
            {
                match = connection.TblUsers
                    .Where(x => x.Email == email && x.Password == password)
                    .FirstOrDefault()?.UserId > 0;
            }
            return match;


        }

        public TblUserModel? validateCredentialWithData(string email, string password)
        {
            if (email == "test@gmail.com" && password == "Abc@123")
            {
                return new TblUserModel()
                {
                    UserId = 1,
                    Email = "test@gmail.com",
                    FullName = "Naitik Gondaliya"
                };
            }
            else
            {
                return null;
            }
        }

        //public async Task<APIResponseModel> Add(TblUserModel MobileNumber)
        //{
        //    APIResponseModel responseModel = new();
        //    try
        //    {
        //        using(var connection = _hsmDbContext)
        //        {
        //            bool duplicateMobileNumber = connection.TblUsers
        //                .Any(x => x.UserId == TblUserModel.MobilNumber);

        //            if (duplicateMobileNumber)
        //            {
        //                _ = await connection.TblUsers.AddAsync(MobileNumber);
        //                connection.SaveChanges();

        //                responseModel.Data = true;
        //                responseModel.StatusCode = HttpStatusCode.OK;
        //                responseModel.Message = "MobilNumber Add Successfully";

        //            }
        //            else
        //            {
        //                responseModel.StatusCode = HttpStatusCode.BadRequest;
        //                responseModel.Message = "Duplicate MobileNumber ";
        //                responseModel.Data = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        responseModel.StatusCode = HttpStatusCode.InternalServerError;
        //        responseModel.Message = ex.InnerException.Message;
        //        responseModel.Data = null;
        //    }

        //}
        public async Task<APIResponseModel> AddRoleId(TblUserModel model)
        {
            APIResponseModel responseModel = new();
            try
            {

                using (var connection = _hsmDbContext)
                {
                    bool id = connection.TblUsers.Any(x => x.UserId == model.UserId);

                    if (id)
                    {
                        _ = await connection.TblUsers.AddAsync(model);
                        connection.SaveChanges();

                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Add Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Invalid User ID";
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

        Task<APIResponseModel> ITblUser.GetAll(string? searchBy)
        {
            throw new NotImplementedException();
        }

        Task<APIResponseModel> ITblUser.validateCredential(string email, string password)
        {
            throw new NotImplementedException();
        }

        Task<APIResponseModel> ITblUser.validateCredentialWithData(string email, string password)
        {
            throw new NotImplementedException();
        }

        Task<APIResponseModel> ITblUser.SignupUser(TblUserModel userModel)
        {
            throw new NotImplementedException();
        }

        Task<APIResponseModel> ITblUser.ForgetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponseModel> MobileNumber()
        {
            throw new NotImplementedException();
        }

        public Task<APIResponseModel> AddRoleId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
