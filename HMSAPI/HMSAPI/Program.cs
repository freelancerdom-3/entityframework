using HMSAPI.EFContext;
using HMSAPI.Service.TblRole;
using HMSAPI.Service.TblHospitalDept;
using HMSAPI.Service.TblHospitalTyp;
using HMSAPI.Service.TblDiseaseType;
using HMSAPI.Service.TblMedicineType;
using HMSAPI.Service.TblUser;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




var configdata = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
string? DFConnection = configdata.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HSMDBContext>(options => options.UseSqlServer("DFConnection"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Custom services
builder.Services.AddScoped<ITblUser, TblUser>();
builder.Services.AddScoped<ITblHospitalDept, TblHospitalDept>();
builder.Services.AddScoped<ITblRole, TblRole>();

builder.Services.AddScoped<ITblDiseaseType, TblDiseaseType>();
builder.Services.AddScoped<ITblMedicineType, TblMedicineType>();

builder.Services.AddScoped<ITblHospitalTyp, TblHospitslTyp>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
