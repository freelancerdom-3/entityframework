using HMSAPI.EFContext;
using HMSAPI.Model.TblUser;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

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
                if (data!=null) {
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
                lstUsers = string.IsNullOrEmpty(searchBy)? connection.TblUsers.ToList():
                    connection.TblUsers.Where(x=>x.FullName.ToLower()==searchBy.ToLower()).
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
    }
}
