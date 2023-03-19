using RestApi.Models;

namespace RestApi.Services;

public interface IHouseService
{
  Task<IEnumerable<House>> GetAll();

  Task<House> Get(int id);
}
