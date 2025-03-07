﻿using HMSAPI.Model.TblDiseaseType;
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

//using HMSAPI.Model.TblEmployeeshiftMapping.ViewModel;
using Microsoft.EntityFrameworkCore;


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
;            base.OnModelCreating(modelBuilder); 

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


            modelBuilder.Entity<TblEmployeeshiftMappingModel>().ToTable("TblEmployeeshiftMapping");
            modelBuilder.Entity<TblTreatmentDetailsModel>().ToTable("TblTreatmentDetails");
            modelBuilder.Entity<TblPateintDoctormappingModel>().ToTable("TblPateintDoctormapping");
            modelBuilder.Entity<TblMedicineDetailsModel>().ToTable("TblMedicineDetails");




            modelBuilder.Entity<TblPatientAdmitionDetailsModel>().ToTable("TblPatientAdmitionDetails");  //patientAdmitionDaetails
        }


        public DbSet<TblMedicineTypeModel> TblMedicineTypes { get; set; }

        public DbSet<TblUserModel> TblUsers { get; set; }
        public DbSet<GetTblUserViewModel> GetTblUserViewModel { get; set; }
        public DbSet<TblDiseaseTypeModel> tblDiseaseTypes { get; set; }
        public DbSet<TblRoleModel> TblRoles { get; set; }

        public DbSet<TblHospitalTypeModel> TblHospitalTypes { get; set; }

        public DbSet<TblHospitalDepartmentModel> TblHospitalDepts { get; set; }
        public DbSet<TblShiftModel> TblShifts { get; set; }

        public DbSet <TblEmployeeDepartmentMappingModel> TblEmployeeDepartmentMappings{ get; set; }

        public DbSet<TblMedicineDiseaseMappingModel> TblMedicineDiseaseMappings { get; set; }
        public DbSet<GetTblMedicineDiseaseMappingViewModel> GetTblMedicineDiseaseMappingViewModels { get; set; }

        public DbSet <GetTblEmployeeDepartmentmappingViewModel> GetTblEmployeeDepartmentMappingViewModel { get;set; }
        public DbSet<TblRoomLocationModel> TblRoomLocations { get; set; }
        public DbSet<TblRoomModel> TblRoom { get; set; }
        public DbSet<TblRoomTypeModel> tblRoomTypes { get; set; }
        public DbSet<TblEmployeeshiftMappingModel> TblEmployeeshifts { get; set; }

        public DbSet<TblPatientModel> TblPatients { get; set; }
        public DbSet<TblTreatmentDetailsModel> TblTreatmentDetails { get; set; } 
        public DbSet<TblPateintDoctormappingModel> TblPateintDoctormappingModels { get; set; }

        public DbSet<GetTblTreatmentDetailsViewModel> GetTblTreatmentDetailsViewModel { get; set; }
      
        public DbSet<TblMedicineDetailsModel> TblMedicineDetails { get; set; }



        //public DbSet<GetTblEmployeeshiftMappingViewModel> GetTblEmployeeshiftMappingViewModels {  get; set; }



        public DbSet<TblPatientAdmitionDetailsModel> tblPatientAdmitionDetails { get; set; } //PatientAdmitionDetails


        public DbSet<GetTblPatientAdmitionDetailsViewModel> GetTblPatientAdmitionDetailsViewModels { get; set; }


        public DbSet<GetPateintDoctorMappingViewModel> GetTblTreatmentDetailsViewModels { get; set; }
        
        public DbSet<GetTblPatientAdmitionDetailsViewModel> GetTblPatientAdmitionDetailsViewModel { get; set; }
        public DbSet<GetMedicineDetailsViewModel> GetMedicineDetailsViewModel { get; set; }

        public DbSet <GetPateintDoctorMappingViewModel>GetPateintDoctorMappingViewModels { get; set; }

    }
}

