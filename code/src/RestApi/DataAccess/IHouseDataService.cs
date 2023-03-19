using RestApi.DataAccess.Models;

namespace RestApi.DataAccess;

public interface IHouseDataService
{
  Task<IEnumerable<House>> GetAll();

  Task<House> Get(int id);
}
