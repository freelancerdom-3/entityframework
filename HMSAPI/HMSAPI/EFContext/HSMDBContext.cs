using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Model.TblMedicineType;
using HMSAPI.Model.TblUser;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblShift;
using HMSAPI.Model.TblUser.ViewModel;
using HMSAPI.Model.TblHospitalDepartment;
using HMSAPI.Model.TblEmployeeDepartmentMapping;
using HMSAPI.Model.TblEmpyloeeDepartmentMapping.ViewModel;
using HMSAPI.Model.TblMedicineDiseaseMapping;
using HMSAPI.Model.TblMedicineDiseaseMapping.ViewModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblRoomLocation;
using HMSAPI.Model.TblRoom;
using HMSAPI.Model.TblRole;
using HMSAPI.Model.TblEmployeeshiftMapping;
using HMSAPI.Model.TblPatient;
using HMSAPI.Model.TblTreatmentDetails.ViewModel;
using HMSAPI.Model.TblPateintDoctormapping.ViewModel;
using HMSAPI.Model.TblTreatmentDetails;
using HMSAPI.Model.TblPateintDoctormapping;
using HMSAPI.Model.TblMedicineDetails;
using HMSAPI.Model.TblPatientAdmitionDetails;
using HMSAPI.Model.TblPatientAdmitionDetails.ViewModel;
using HMSAPI.Model.TblMedicineDetails.ViewModel;
using HMSAPI.Model.TblPatient.ViewModel;
using HMSAPI.Model.TblFeedback;
using Microsoft.EntityFrameworkCore;
using HMSAPI.Model.TblBill;
using HMSAPI.Model.TblBill.ViewModel;
using HMSAPI.Model.TblFacilityTypes;
using HMSAPI.Model.TblFacility;
using HMSAPI.Model.TblRoomTypeFacilityMapping.View_Model;
using HMSAPI.Model.TblRoomTypeFacilityMapping;
using HMSAPI.Model.TblRoom.View_Model;
using HMSAPI.Model.TblRoomLocation.View_Model;
using HMSAPI.Model.TblFeedback.ViewModel;
using HMSAPI.Model.TblEmployeeshiftMapping.ViewModel;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMenuRoleMapping;



namespace HMSAPI.EFContext
{
    public class HSMDBContext : DbContext
    {

        public HSMDBContext(DbContextOptions<HSMDBContext> option) : base(option)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configdata = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            string? DFConnection = configdata.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(DFConnection);
            base.OnConfiguring(optionsBuilder);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblMedicineTypeModel>().ToTable("TblMedicineType");
            modelBuilder.Entity<TblUserModel>().ToTable("TblUser");

            modelBuilder.Entity<TblRoleModel>().ToTable("TblRole");
            modelBuilder.Entity<TblHospitalTypeModel>().ToTable("TblHospitalType");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblDiseaseTypeModel>().ToTable("TblDiseaseType");
            ; base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TblHospitalDepartmentModel>().ToTable("TblHospitalDepartment");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblEmployeeDepartmentMappingModel>().ToTable("TblEmployeeDepartmentMapping");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblMedicineDiseaseMappingModel>().ToTable("TblMedicineDiseaseMapping");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblRoomTypeModel>().ToTable("TblRoomType");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblRoomModel>().ToTable("TblRoom");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblRoomLocationModel>().ToTable("TblRoomLocations");
            modelBuilder.Entity<TblShiftModel>().ToTable("TblShift");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblPatientModel>().ToTable("TblPatient");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblFeedbackModel>().ToTable("Tblfeedback");
            modelBuilder.Entity<TblBillModel>().ToTable("TblBill");
            modelBuilder.Entity<TblMenuRoleMapping>().ToTable("TblMenuRoleMapping");



            modelBuilder.Entity<TblEmployeeshiftMappingModel>().ToTable("TblEmployeeshiftMapping");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblTreatmentDetailsModel>().ToTable("TblTreatmentDetails");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblPateintDoctormappingModel>().ToTable("TblPateintDoctormapping");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblMedicineDetailsModel>().ToTable("TblMedicineDetails");
            modelBuilder.Entity<TblFacilityModel>().ToTable("TblFacility");
            modelBuilder.Entity<TblFacilityTypeModels>().ToTable("TblfacilityType");
            modelBuilder.Entity<TblRoomTypeFacilityMappingModel>().ToTable("TblRoomTypeFacilityMapping");
            modelBuilder.Entity<TblPatientAdmitionDetailsModel>().ToTable("TblPatientAdmitionDetails");

        }


        public DbSet<TblMedicineTypeModel> TblMedicineTypes { get; set; }

        public DbSet<TblUserModel> TblUsers { get; set; }
        public DbSet<GetTblUserViewModel> GetTblUserViewModel { get; set; }
        public DbSet<TblDiseaseTypeModel> TblDiseaseType { get; set; }
        public DbSet<TblRoleModel> TblRoles { get; set; }

        public DbSet<TblHospitalTypeModel> TblHospitalTypes { get; set; }

        public DbSet<TblHospitalDepartmentModel> TbLHospitalDepartment { get; set; }
        public DbSet<TblShiftModel> TblShifts { get; set; }

        public DbSet<TblEmployeeDepartmentMappingModel> TblEmployeeDepartmentMappings { get; set; }

        public DbSet<TblMedicineDiseaseMappingModel> TblMedicineDiseaseMappings { get; set; }
        public DbSet<GetTblMedicineDiseaseMappingViewModel> GetTblMedicineDiseaseMappingViewModels { get; set; }

        public DbSet<GetTblEmployeeDepartmentmappingViewModel> GetTblEmployeeDepartmentMappingViewModel { get; set; }
        public DbSet<TblRoomLocationModel> TblRoomLocations { get; set; }
        public DbSet<TblRoomModel> TblRoom { get; set; }
        public DbSet<TblRoomTypeModel> tblRoomTypes { get; set; }
        public DbSet<TblEmployeeshiftMappingModel> TblEmployeeshifts { get; set; }

        public DbSet<TblPatientModel> TblPatients { get; set; }
        public DbSet<TblTreatmentDetailsModel> TblTreatmentDetails { get; set; }
        public DbSet<TblPateintDoctormappingModel> TblPateintDoctormappingModels { get; set; }

        public DbSet<GetTblTreatmentDetailsViewModel> GetTblTreatmentDetailsViewModel { get; set; }

        public DbSet<TblMedicineDetailsModel> TblMedicineDetails { get; set; }
        public DbSet<TblPatientAdmitionDetailsModel> tblPatientAdmitionDetails { get; set; }
        public DbSet<GetPateintDoctorMappingViewModel> getPateintDoctorMappingViewModels { get; set; }

        public DbSet<GetTblPatientAdmitionDetailsViewModel> GetTblPatientAdmitionDetailsViewModel { get; set; }
        public DbSet<GetMedicineDetailsViewModel> GetMedicineDetailsViewModel { get; set; }

        public DbSet<GetPateintDoctorMappingViewModel> GetPateintDoctorMappingViewModels { get; set; }

        public DbSet<GetTblPatientViewModel> GetTblPatientViewModel { get; set; }

        public DbSet<GetTblPatientViewModel2> GetTblPatientViewModel2 { get; set; }

        public DbSet<TblFeedbackModel> TblFeedbacks { get; set; }

        public DbSet<TblBillModel> TblBills { get; set; }

        public DbSet<BillPatientViewModel> billPatientViewModels { get; set; }

        public DbSet<GetDropDownListModel> GetDropDownListModel { get; set; }

        public DbSet<TblFacilityTypeModels> TblFacilityTypes { get; set; }
        public DbSet<TblFacilityModel> TblFacility { get; set; }
        public DbSet<TblRoomTypeFacilityMappingModel> TblRoomTypeFacilityMapping { get; set; }
        public DbSet<GetTblRoomTypeFacilityMappingModel> GetTblRoomTypeFacilityMappingModel { get; set; }
        public DbSet<GetTblRoomModel> GetTblRoomModel { get; set; }
        public DbSet<GetTblRoomLocationModel> GetTblRoomLocationModel { get; set; }

        public DbSet<GetTblFeedbackViewModel> GetTblFeedbackViewModel { get; set; }

        public DbSet<GetTblEmployeeshiftMappingViewModel> getTblEmployeeshiftMappingViewModel { get; set; }
        public DbSet<TblMenuRoleMapping> TblMenuRolemapping { get; set; }
        public DbSet<GetTblRoomTypeViewModel> GetTblRoomTypeViewModel { get; set; }
        public DbSet<TblHospitalDepartmentViewModel> TblHospitalDepartmentViewModel { get; set; }

        public DbSet<GetTblMedicineTypeViewModel> GetTblMedicineTypeViewModels { get; set; }

        public DbSet<GetTblRoleViewModel> getTblRoleViewModels { get; set; }

        public DbSet<GetTblShiftViewModel> GetTblShiftViewModel { get; set; }
        public DbSet<GetTblHospitalTypeModel> getTblHospitalTypeModels { get; set; }
        public DbSet<GetPatientMappingViewModel> getPatientMappingViewModels { get; set; }
        public DbSet<GetTblRoomTypeFacilityMapping> gettblroomtypefacilitymapping { get; set; }

        public DbSet<GetEmployeeMapping> getEmployeeMappings { get; set; }

        public DbSet<TblEmployeeDepartment> tblEmployeeDepartments { get; set; }

        public DbSet<Gettbltreatmentmodel> gettbltreatmentmodels { get; set; }

        public DbSet<getdiseasetypeviewmodel> getdiseasetypeviewmodels { get; set; }

        public DbSet<GetTblPatientAdmitionViewModel> getTblPatientAdmition { get; set; }

        public DbSet<GetTblFacilityTypeModels> gettblfacilitytypemodels {  get; set; }
    }
}

