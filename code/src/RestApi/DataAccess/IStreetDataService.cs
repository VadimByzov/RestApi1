using RestApi.DataAccess.Models;

namespace RestApi.DataAccess;

public interface IStreetDataService
{
  Task<IEnumerable<Street>> GetAll();

  Task<Street> Get(int id);
}
