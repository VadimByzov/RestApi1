using RestApi.DataAccess;
using RestApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Db init service
builder.Services.AddTransient<IDatabaseInitializationService, MssqlInitializationService>();

// Data services
builder.Services.AddTransient<ICityDataService, CityDataService>();
builder.Services.AddTransient<IStreetDataService, StreetDataService>();
builder.Services.AddTransient<IHouseDataService, HouseDataService>();
builder.Services.AddTransient<IApartmentDataService, ApartmentDataService>();

// Business services
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IStreetService, StreetService>();
builder.Services.AddTransient<IHouseService, HouseService>();
builder.Services.AddTransient<IApartmentService, ApartmentService>();

builder.Services.AddControllers();

var app = builder.Build();

app.Services.GetService<IDatabaseInitializationService>().Initialize();

app.MapControllers();

app.Run();
