using GestionExpropaciones.Configurations;
using GestionExpropaciones.Extensions;
using GestionExpropaciones.Services;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Common;
using GestionExpropaciones.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration);
builder.Services.AddDefaultServices(builder.Configuration);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IOwnerPropertyService, OwnerPropertyService>();
builder.Services.AddScoped<IPaperWorkService, PaperWorkService>();
builder.Services.AddScoped<IExpropiatedPropertyService, ExpropiatedPropertyService>();
builder.Services.AddScoped<IAppraisalService, AppraisalService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IOwnerPropertyRepository, OwnerPropertyRepository>();
builder.Services.AddScoped<IPaperWorkRepository, PaperWorkRepository>();
builder.Services.AddScoped<IExpropiatedPropertyRepository, ExpropiatedPropertyRepository>();
builder.Services.AddScoped<IAppraisalRepository, AppraisalRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.ApplyMigrations();

app.ConfigureAppPipeline(app.Environment);

app.MapControllers();

app.Run();