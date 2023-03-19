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
      StreetId = dataHouse.Street_Id
    };
  }

  public async Task<IEnumerable<House>> GetAll()
  {
    var dataHouses = await _houseDataService.GetAll();
    return dataHouses.Select(h => new House
    {
      Id = h.Id,
      Number = h.Number,
      StreetId = h.Street_Id,
    });
  }

  public async Task<IEnumerable<House>> GetByStreetId(int streetId)
  {
    var dataHouses = await _houseDataService.GetByStreetId(streetId);
    return dataHouses.Select(h => new House
    {
      Id = h.Id,
      Number = h.Number,
      StreetId = h.Street_Id,
    });
  }

  public async Task<IEnumerable<House>> GetByCityId(int cityId)
  {
    var dataHouses = await _houseDataService.GetByCityId(cityId);
    return dataHouses.Select(h => new House
    {
      Id = h.Id,
      Number = h.Number,
      StreetId = h.Street_Id
    });
  }
}
