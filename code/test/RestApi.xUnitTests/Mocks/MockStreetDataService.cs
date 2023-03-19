using RestApi.DataAccess;
using RestApi.DataAccess.Models;
using RestApi.Exceptions;

namespace RestApi.xUnitTests.Mocks;

internal class MockStreetDataService : IStreetDataService
{
  public MockStreetDataService(List<Street> streets)
  {
    _streets = streets;
  }

  private readonly List<Street> _streets;

  public async Task<IEnumerable<Street>> GetAll()
  {
    return await Task.Run(() => _streets);
  }

  public async Task<Street> Get(int id)
  {
    var result = await Task.Run(() => _streets.Where(s => s.Id == id));
    if (!result.Any()) throw new NotFoundException("nfe");
    return result.First();
  }

  public async Task<IEnumerable<Street>> GetByCityId(int cityId)
  {
    return await Task.Run(() => _streets.Where(s => s.City_Id == cityId));
  }
}
