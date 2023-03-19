using RestApi.Models;

namespace RestApi.Services;

public interface IApartmentService
{
  Task<IEnumerable<Apartment>> GetAll();

  Task<Apartment> Get(int id);
}
