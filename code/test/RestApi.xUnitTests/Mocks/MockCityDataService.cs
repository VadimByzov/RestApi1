using RestApi.DataAccess;
using RestApi.DataAccess.Models;
using RestApi.Exceptions;

namespace RestApi.xUnitTests.Mocks;

internal class MockCityDataService : ICityDataService
{
  public MockCityDataService(List<City> cities)
  {
    _cities = cities;
  }

  private readonly List<City> _cities;

  public async Task<IEnumerable<City>> GetAll()
  {
    return await Task.Run(() => _cities);
  }

  public async Task<City> Get(int id)
  {
    var result = await Task.Run(() => _cities.Where(c => c.Id == id));
    if (!result.Any()) throw new NotFoundException("nfe");
    return result.First();
  }
}
