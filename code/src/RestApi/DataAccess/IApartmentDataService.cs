using RestApi.DataAccess.Models;

namespace RestApi.DataAccess;

public interface IApartmentDataService
{
  Task<IEnumerable<Apartment>> GetAll();

  Task<Apartment> Get(int id);
}
