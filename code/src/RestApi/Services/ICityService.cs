using RestApi.Models;

namespace RestApi.Services;

public interface ICityService
{
  Task<IEnumerable<City>> GetAll();

  Task<City> Get(int id);
}
