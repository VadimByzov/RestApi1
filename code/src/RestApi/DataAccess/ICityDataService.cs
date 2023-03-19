using RestApi.DataAccess.Models;

namespace RestApi.DataAccess;

public interface ICityDataService
{
  Task<IEnumerable<City>> GetAll();

  Task<City> Get(int id);
}
