using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblPatientAdmitionDetails.ViewModel
{
    public class GetTblPatientAdmitionDetailsViewModel //:TblPatientAdmitionDetailsModel


    {

        [Key]
        public int PatientAdmitionDetailsId { get; set; }
        public int UserId { get; set; }
        public DateTime AdmisionDate { get; set; }

        public int RoomID { get; set; }
        public int TreatmentDetailsId { get; set; }

        public DateTime? DischargeDate { get; set; } = null;

        public string? FullName { get; set; }



        //fro room
       // public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeID { get; set; }


        //user
        //public int UserId { get; set; }
        //public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RoleName { get; set; }



        //public int UserId { get; set; }



        //public int RoomNumber { get; set; }

        //public int RoomID { get; set; }
    }
}
