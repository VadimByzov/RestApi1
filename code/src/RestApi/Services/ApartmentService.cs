using RestApi.DataAccess;
using RestApi.Models;

namespace RestApi.Services;

public class ApartmentService : IApartmentService
{
  public ApartmentService(IApartmentDataService apartmentDataService)
  {
    _apartmentDataService = apartmentDataService;
  }

  private readonly IApartmentDataService _apartmentDataService;

  public async Task<Apartment> Get(int id)
  {
    var dataApartment = await _apartmentDataService.Get(id);
    return new Apartment
    {
      Id = dataApartment.Id,
      Area = dataApartment.Area,
      HouseId = dataApartment.HouseId,
    };
  }

  public async Task<IEnumerable<Apartment>> GetAll()
  {
    var dataApartments = await _apartmentDataService.GetAll();
    return dataApartments.Select(a => new Apartment
    {
      Id = a.Id,
      Area = a.Area,
      HouseId = a.HouseId,
    });
  }
}
