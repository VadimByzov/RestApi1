using RestApi.DataAccess;
using RestApi.DataAccess.Models;
using RestApi.Exceptions;

namespace RestApi.xUnitTests.Mocks;

internal class MockHouseDataService : IHouseDataService
{
  public MockHouseDataService(List<House> houses,
    List<Street> streets)
  {
    _houses = houses;
    _streets = streets;
  }

  private readonly List<House> _houses;

  private readonly List<Street> _streets;

  public async Task<IEnumerable<House>> GetAll()
  {
    return await Task.Run(() => _houses);
  }

  public async Task<House> Get(int id)
  {
    var result = await Task.Run(() => _houses.Where(h => h.Id == id));
    if (!result.Any()) throw new NotFoundException("nfe");
    return result.First();
  }

  public async Task<IEnumerable<House>> GetByStreetId(int streetId)
  {
    return await Task.Run(() => _houses.Where(h => h.Street_Id == streetId));
  }

  public async Task<IEnumerable<House>> GetByCityId(int cityId)
  {
    return await Task.Run(() => _streets
      .Where(s => s.City_Id == cityId)
      .Join(_houses,
        street => street.Id,
        house => house.Street_Id,
        (street, house) => house
      )
    );
  }
}
