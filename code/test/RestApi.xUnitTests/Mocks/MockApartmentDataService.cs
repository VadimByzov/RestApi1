using RestApi.DataAccess;
using RestApi.DataAccess.Models;

namespace RestApi.xUnitTests.Mocks;

internal class MockApartmentDataService : IApartmentDataService
{
  public MockApartmentDataService()
  {

  }

  public Task<IEnumerable<Apartment>> GetAll()
  {
    throw new NotImplementedException();
  }

  public Task<Apartment> Get(int id)
  {
    throw new NotImplementedException();
  }
}
