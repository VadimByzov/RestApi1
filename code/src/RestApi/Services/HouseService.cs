using RestApi.DataAccess;
using RestApi.Models;

namespace RestApi.Services;

public class HouseService : IHouseService
{
  public HouseService(IHouseDataService houseDataService)
  {
    _houseDataService = houseDataService;
  }

  private readonly IHouseDataService _houseDataService;

  public async Task<House> Get(int id)
  {
    var dataHouse = await _houseDataService.Get(id);
    return new House
    {
      Id = id,
      Number = dataHouse.Number,
      StreetId = dataHouse.StreetId
    };
  }

  public Task<IEnumerable<House>> GetAll()
  {
    throw new NotImplementedException();
  }
}
