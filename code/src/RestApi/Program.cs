using RestApi.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<IDatabaseInitializationService, MssqlInitializationService>();

var app = builder.Build();

app.Services.GetService<IDatabaseInitializationService>().Initialize();

app.MapControllers();

app.Run();
