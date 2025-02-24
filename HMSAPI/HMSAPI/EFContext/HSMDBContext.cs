using HMSAPI.Model.TblUser;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.EFContext
{
    public class HSMDBContext:DbContext
    {
        public HSMDBContext(DbContextOptions<HSMDBContext> option):base(option)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection related changes 
            //prepare .json file, add connection string
            //Connection string : servername, dbname, authentication type, secure,
            // register here,
            var configdata = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json",optional:false)
                .Build();
            string? DFConnection = configdata.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(DFConnection);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblUserModel>().ToTable("TblUser");
            base.OnModelCreating(modelBuilder); 

        }

        public DbSet<TblUserModel> TblUsers { get; set; }
    }
}
