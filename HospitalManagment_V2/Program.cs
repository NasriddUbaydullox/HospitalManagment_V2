using HospitalManagment_V2.classes;
using HospitalManagment_V2.DataAccess;
using HospitalManagment_V2.MapperProfile;
using HospitalManagment_V2.Middleware;
using HospitalManagment_V2.Repository;
using HospitalManagment_V2.Services;
using Microsoft.EntityFrameworkCore;
using Sats.PostgreSqlDistributedCache;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<FileStorage>(builder.Configuration.GetSection("MedicalRecordsPath"));
builder.Services.Configure<FileStorage>(builder.Configuration.GetSection("ReportsPath"));

builder.Services.Configure<AppointmentSettings>(builder.Configuration.GetSection("CancellationDeadlineHours"));
builder.Services.Configure<AppointmentSettings>(builder.Configuration.GetSection("NotificationReminderHours"));

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<ICorroletionId, CorreletionId>();

//builder.Services.AddPostgresDistributedCache(options =>
//{
//    options.ConnectionString = "Server=localhost;Port=5432;Database=HospitalManagmentV2;User Id=postgres;Password=postgres;";
//});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
    options.InstanceName = "test";
}); 

builder.Services.AddMemoryCache();

builder.Services.AddDbContext<Context>(options =>
{
    options
        .UseNpgsql("Server=localhost;Port=5432;Database=HospitalManagmentV2;User Id=postgres;Password=postgres;")
        .LogTo(Console.WriteLine, LogLevel.Information);
});


#region Serilog
// Serilog konfiguratsiyasi
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()  // Logs to console
    .WriteTo.Seq("http://localhost:5341")  // Logs to Seq
    .Enrich.FromLogContext()
    .MinimumLevel.Information() 
    .CreateLogger();

// Replace default logging with Serilog
builder.Host.UseSerilog();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseMiddleware<CorreletionIdMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
