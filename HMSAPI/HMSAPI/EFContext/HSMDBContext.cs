using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Model.TblMedicineType;
using HMSAPI.Model.TblUser;
using Microsoft.EntityFrameworkCore;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblShift;
using HMSAPI.Model.TblUser.ViewModel;
using HMSAPI.Model.TblHospitalDepartment;
using HMSAPI.Model.TblEmployeeDepartmentMapping;
using HMSAPI.Model.TblEmpyloeeDepartmentMapping.ViewModel;
using HMSAPI.Model.TblMedicineDiseaseMapping;
using HMSAPI.Model.TblMedicineDiseaseMapping.ViewModel;
using HMSAPI.Service.TblHospitalTyp;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblRoomLocation;
using HMSAPI.Service.TblRoomLocations;
using HMSAPI.Service.TblRoomType;
using HMSAPI.Model.TblRoom;
using HMSAPI.Model.TblRole;
using HMSAPI.Model.TblEmployeeshiftMapping;

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
            base.OnModelCreating(modelBuilder);

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
    }
}

