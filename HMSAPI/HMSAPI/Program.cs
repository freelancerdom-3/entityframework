using HMSAPI.EFContext;
using HMSAPI.Service.TblRole;
using HMSAPI.Service.TblHospitalDept;
using HMSAPI.Service.TblHospitalTyp;
using HMSAPI.Service.TblDiseaseType;
using HMSAPI.Service.TblMedicineType;
using HMSAPI.Service.TblUser;
using Microsoft.EntityFrameworkCore;
using HMSAPI.Service.TblShift;
using HMSAPI.Service.TblEmployeeDepartmentMapping;
using HMSAPI.Service.TblRoomLocations;
using HMSAPI.Service.TblHospitalType;
using HMSAPI.Service.TblPatient;
using HMSAPI.Service.TblMedicineDiseaseMapping;
using HMSAPI.Service.TblEmployeeshiftMapping;
using HMSAPI.Service.TblPateintDoctormapping;
using HMSAPI.Service.TblTreatmentDetails;
using HMSAPI.Service.TblMedicineDetails;
using HMSAPI.Service.TblPatientAdmitionDetails;
using HMSAPI.Service.TblFeedback;
using HMSAPI.Service.TblBill;
using HMSAPI.Service.TblFacilityTypes;
using HMSAPI.Service.TblFacility;
using HMSAPI.Service.TblRoomTypeFacilityMapping;
using HMSAPI.Service.TblFacility;
using HMSAPI.Service.TblFacilityTypes;
using HMSAPI.Service.GetDropDownList;
using HMSAPI.Service.TblRoom;
using HMSAPI.Service.RoomType;
using HMSAPI.Service.TblRoomType;

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
builder.Services.AddScoped<ITblHospitalDepartment, TblHospitalDepartment>();
builder.Services.AddScoped<ITblRole, TblRole>();
builder.Services.AddScoped<ITblShift, TblShift>();
builder.Services.AddScoped<ITblDiseaseType, TblDiseaseType>();
builder.Services.AddScoped<ITblMedicineType, TblMedicineType>();
builder.Services.AddScoped<ITblHospitalType, TblHospitalType>();
builder.Services.AddScoped<ITblEmployeeDepartmentMapping, TblEmployeeDepartmentMapping>();
builder.Services.AddScoped<ITblRoomLocations ,TblRoomLocations>();
builder.Services.AddScoped<ITblPatient, TblPatient>();
builder.Services.AddScoped<ITblMedicineDiseaseMapping, TblMedicineDiseaseMapping>();
builder.Services.AddScoped<ITblEmployeeshiftMapping, TblEmployeeshiftMapping>();
builder.Services.AddScoped<ITblPateintDoctormapping, TblPateintDoctormapping>();
builder.Services.AddScoped<ITblTreatmentDetails, TblTreatmentDetails>();
builder.Services.AddScoped<ITblMedicineDetails, TblMedicineDetails>();
builder.Services.AddScoped<ITblPatientAdmitionDetails, TblPatientAdmitionDetails>();
builder.Services.AddScoped<ITblRoomTypeFacilityMapping, TblRoomTypeFacilityMapping>();
builder.Services.AddScoped<ITblFacility, TblFacility>();
builder.Services.AddScoped<ITblFacilityTypes, TblFacilityTypes>();
builder.Services.AddScoped<ITblBill, TblBill>();




builder.Services.AddScoped<ITblPatientAdmitionDetails, TblPatientAdmitionDetails>();
builder.Services.AddScoped<ITblFeedback, TblFeedback>();
builder.Services.AddScoped<ITblFacilityTypes, TblFacilityTypes>();
builder.Services.AddScoped<ITblFacility, TblFacility>();
builder.Services.AddScoped<ITblRoom, TblRoom>();
builder.Services.AddScoped<ITblRoomType, TblRoomType>();


builder.Services.AddScoped<IGetDropDownList, GetDropDownList>();

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
