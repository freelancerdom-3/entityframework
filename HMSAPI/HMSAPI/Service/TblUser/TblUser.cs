using HMSAPI.EFContext;
using HMSAPI.Model.TblUser;
using System.Collections.Generic;

namespace HMSAPI.Service.TblUser
{
    public class TblUser : ITblUser
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblUser(HSMDBContext hSMDBContext)
        {
                _hsmDbContext = hSMDBContext;
        }

        public List<TblUserModel> GetAll()
        {
            List<TblUserModel> lstUsers = new();
            using (var connection = _hsmDbContext)
            {
                lstUsers= connection.TblUsers.ToList();
            }
            return lstUsers;

        }

        public bool validateCredential(string email, string password)
        {
            bool match = false;
            using (var connection = _hsmDbContext)
            {
                match = connection.TblUsers
                    .Where(x => x.Email == email && x.Password == password)
                    .FirstOrDefault().UserId > 0;
            }
            return match;

            
        }

        public TblUserModel? validateCredentialWithData(string email, string password)
        {
            if (email == "test@gmail.com" && password == "Abc@123")
            {
                return new TblUserModel() {
                    UserId=1,
                    Email="test@gmail.com",
                    FullName="Naitik Gondaliya"
                };
            }
            else
            {
                return null;
            }
        }
    }
}
