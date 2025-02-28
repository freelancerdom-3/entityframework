using HMSAPI.EFContext;
using HMSAPI.Model.RoomTypeModel;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace HMSAPI.Service.RoomType
{
    public class RoomType : IRoomType
    {
        private readonly HSMDBContext _hsmDbContext;
        public RoomType(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }


        public List<RoomTYpeModel> getAll(string? searchBy = null)
        {
            List<RoomTYpeModel> lstUsers = new();
            using (var connection = _hsmDbContext)
            {
                lstUsers = string.IsNullOrEmpty(searchBy) ? connection.RoomTYpes.ToList() :
                    connection.RoomTYpes.Where(x => x.RoomType.ToLower() == searchBy.ToLower()).
                    ToList();
            }
            return lstUsers;
        }

        public bool AddRoomTyp(RoomTYpeModel roomTYpe)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                bool duplicateName = connection.RoomTYpes
                .Any(x =>x.RoomType==roomTYpe.RoomType);

                if (!duplicateName)
                {
                    //_hsmDbContext.RoomTypes.Add(RoomTypModel);

                    //_hsmDbContext.SaveChanges();
                    _ = connection.RoomTYpes.Add(roomTYpe);
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
        public bool UpdateRoomTyp(int id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                RoomTYpeModel? data = connection.RoomTYpes.Where(x => x.RoomId == id).FirstOrDefault();
                if (data != null)
                {
                    data.RoomType = "General";
                    connection.Update(data);
                    connection.SaveChanges();
                    result = true;

                }
                else
                {
                    result = false;
                }
                return result;
            }
        }
        public bool DeleteRoomTyp(int id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                RoomTYpeModel? data = connection.RoomTYpes.Where(x => x.Id == id).FirstOrDefault();
                if (data != null)
                {
                    connection.RoomTYpes.Remove(data);
                    connection.SaveChanges();
                    result = true;

                }
                else
                {
                    result = false;
                }
                return result;
            }

        }
        public RoomTYpeModel? GetById(int id)
        {

            using (var connection = _hsmDbContext)
            {
                RoomTYpeModel data = connection.RoomTYpes.Where(x => x.RoomId == id).FirstOrDefault();
                return data;
            }
        }

        
    }
}
