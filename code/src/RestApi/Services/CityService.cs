using RestApi.DataAccess;
using RestApi.Models;

namespace RestApi.Services;

public class CityService : ICityService
{
  public CityService(ICityDataService cityDataService)
  {
    _cityDataService = cityDataService;
  }

  private readonly ICityDataService _cityDataService;

  public async Task<City> Get(int id)
  {
    var dataCity = await _cityDataService.Get(id);
    return new City
    {
      Id = dataCity.Id,
      Name = dataCity.Name,
    };
  }

  public async Task<IEnumerable<City>> GetAll()
  {
    var dataCities = await _cityDataService.GetAll();
    return dataCities.Select(c => new City
    {
      Id = c.Id,
      Name = c.Name
    });
  }
}
