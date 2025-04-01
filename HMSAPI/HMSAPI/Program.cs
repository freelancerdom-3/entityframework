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
using HMSAPI.Service.GetDropDownList;
using HMSAPI.Service.TblRoom;
using HMSAPI.Service.RoomType;
using HMSAPI.Service.TblRoomType;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HMSAPI.Service.TokenData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using HMSAPI.Service.TokenDate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




var configdata = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
string? DFConnection = configdata.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HSMDBContext>(options => options.UseSqlServer("DFConnection"));


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
options.AddPolicy(name: MyAllowSpecificOrigins,
                  policy =>
                  {
                        policy.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()  
                        .AllowAnyHeader()  
                        .AllowCredentials();
                  });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//JWT Authentication


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthentication();



// Custom services
//builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddScoped<ITokenData, TokenData>();

builder.Services.AddSingleton<ITokenData, TokenData>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
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

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();






