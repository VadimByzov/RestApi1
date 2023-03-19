using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Services;

namespace RestApi.Controllers;

[Route("cities")]
[ApiController]
public class CityController : ControllerBase
{
  public CityController(ICityService cityService)
  {
    _cityService = cityService;
  }

  private readonly ICityService _cityService;

  [HttpGet("")]
  public async Task<IActionResult> GetCities()
  {
    try
    {
      return Ok(await _cityService.GetAll());
    }
    catch (Exception e)
    {
      return BadRequest(new NotFound { Message = e.Message });
    }
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
