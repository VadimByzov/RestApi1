using RestApi.Models;

namespace RestApi.Services;

public interface IStreetService
{
  Task<IEnumerable<Street>> GetAll();

  Task<Street> Get(int id);
}
