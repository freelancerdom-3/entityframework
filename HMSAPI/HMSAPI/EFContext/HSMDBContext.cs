using HMSAPI.Model.TblModel;
using HMSAPI.Model.TblHospitalDep;
using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Model.TblMedicineType;
using HMSAPI.Model.TblUser;
using HMSAPI.Service.TblHospitalDept;
using Microsoft.EntityFrameworkCore;
using HMSAPI.Model.TblHospitalTyp;
using HMSAPI.Model.RoomTypeModel;
using HMSAPI.Model.TblShift;
using HMSAPI.Model.TblUser.ViewModel;

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
            modelBuilder.Entity<TblHospitalTypModel>().ToTable("TblHospitalTyp");
        
            modelBuilder.Entity<TblRoleModel>().ToTable("TblRole");
           
            modelBuilder.Entity<TblDiseaseTypeModel>().ToTable("DiseaseType");
;            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<TblHospitalDeptModel>().ToTable("TblHospitalDept");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TblHospitalTypModel> TblHospitalTypes { get; set; }

        public DbSet<TblMedicineTypeModel> TblMedicineTypes { get; set; }

        public DbSet<TblUserModel> TblUsers { get; set; }
        public DbSet<GetTblUserViewModel> GetTblUserViewModel { get; set; }
        public DbSet<TblDiseaseTypeModel> tblDiseaseTypes { get; set; }
        public DbSet<TblRoleModel> TblRoles { get; set; }

        public DbSet<TblHospitalDeptModel> TblHospitalDepts { get; set; }
        public DbSet<RoomTYpeModel> RoomTYpes { get; set; }
        public DbSet<TblShiftModel> TblShifts { get; set; }
    }
}

