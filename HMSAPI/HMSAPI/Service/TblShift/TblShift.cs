
using HMSAPI.Model.TblShift;
using HMSAPI.EFContext;
namespace HMSAPI.Service.TblShift

{
    public class TblShift : ITblShift
    {

        private readonly HSMDBContext _hsmDbContext;
        //private object connection;

        public TblShift(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public bool AddTimehift(TblShiftModel Shift)
        {
            bool result = true;
            using (var connection = _hsmDbContext)
            {


                // var duplicateShift = connection.TblShifts.Any(x => x.Shiftname.ToLower() == TblShiftModel..ToLower());
                // bool duplicateShift = connection.TblShifts
                // .Any(x => x.TblShift.ToLower() == Shift.TblShiftModel.ToLower());


                if (Shift.Shiftname != null)
                {

                    connection.TblShifts.Add(Shift);
                    connection.SaveChanges();
                }
                else
                {
                    result = false;
                }



            }




            return result;
        }

        public bool deleteshift(int id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {

                TblShiftModel? data = connection.TblShifts.Where(j => j.Shiftid == id).FirstOrDefault();

                if (data != null)
                {
                    connection.TblShifts.Remove(data);
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

        public List<TblShiftModel> GetAll()
        {
            List<TblShiftModel> shitList = new();
            using (var connection = _hsmDbContext)
            {
                shitList = connection.TblShifts.ToList();
            }
            return shitList;
        }

        public TblShiftModel getbyShitid(int id)
        {
            TblShiftModel data = new TblShiftModel();
            using (var connection = _hsmDbContext)
            {
                data = connection.TblShifts.Where(k => k.Shiftid == id).FirstOrDefault();


            }

            return data;

        }

        public bool updateShift(int id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {

                TblShiftModel? data = connection.TblShifts.Where(j => j.Shiftid == id).FirstOrDefault();

                if (data != null)
                {
                    data.Shiftname = "Mornig Night";
                    connection.TblShifts.Update(data);
                    connection.SaveChanges();
                    result = true;

                }

                else
                {
                    result = false;
                }



                // return result;
            }

            return result;
        }














    }


}
