using Microsoft.AspNetCore.Mvc;
using RestApi.DataAccess;

namespace RestApi.Controllers;

[Route("cities")]
[ApiController]
public class CityController : ControllerBase
{
  public CityController(ICityDataService cityDataService)
  {
    _cityDataService = cityDataService;
  }

  private readonly ICityDataService _cityDataService;

  [HttpGet("")]
  public async Task<IActionResult> GetCities()
  {
    return Ok(await _cityDataService.GetAll());
  }

  [HttpGet("{cityId}/streets")]
  public async Task<IActionResult> GetStreets(string cityId)
  {
    // перечень улиц с указанием количества домов с запросом по городу /cities/{city_id}/streets
    return Ok("cities/streets");
  }

  [HttpGet("{cityId}/houses")]
  public async Task<IActionResult> GetHouses(string cityId)
  {
    // перечень домов с указанием полного адреса и количества квартир с запросом по конкретной улице / городу
    return Ok("cities/houses");
  }
}
