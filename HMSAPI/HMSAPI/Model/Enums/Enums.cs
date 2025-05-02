namespace HMSAPI.Model.Enums
{
    public class Enums
    {
        public enum Roles
        {
            Admin = 1,
            Patient = 2,
        }

        public enum Menus
        {
            Master = 1,
            Setting = 2,
            Patients = 3,
            Admin = 4,
            Users = 6,
            HospitalType = 7,
            HospitalDepartment = 8,
            Role = 9,
            Shift = 10,
            DiseaseType = 11,
            MedicineType = 12,
            RoomType = 13,
            FacilityType = 14,
            Employeeshift = 15,
            Room = 16,
            MedicineDisease = 17,
            RoomFacility = 18,
            EmployeeDepartment = 19,
            PatientData = 20,
            TreatmentDetails = 21,
            MedicineDetails = 22,
            AdmissionDetails = 23,
            Billing = 24

        }

        public enum PermissionType
        {
            IsAdd=1,
            IsDelete=2,
            IsEdit=3,
            IsView=4
        }
    }
}
