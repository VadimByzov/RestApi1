using RestApi.Models;

namespace RestApi.Services;

public interface IHouseService
{
  Task<IEnumerable<House>> GetAll();

  Task<House> Get(int id);

  Task<IEnumerable<House>> GetByStreetId(int streetId);

  Task<IEnumerable<House>> GetByCityId(int cityId);
}
