using RestApi.DataAccess.Models;

namespace RestApi.DataAccess;

public interface IHouseDataService
{
  Task<IEnumerable<House>> GetAll();

  Task<House> Get(int id);

  Task<IEnumerable<House>> GetByStreetId(int streetId);

  Task<IEnumerable<House>> GetByCityId(int cityId);
}
