using Microsoft.AspNetCore.Mvc;
using RestApi.DataAccess.Models;
using RestApi.Exceptions;
using RestApi.Services;

namespace RestApi.Controllers;

[Route("cities")]
[ApiController]
public class CityController : ControllerBase
{
  public CityController(ICityService cityService,
    IStreetService streetService,
    IHouseService houseService)
  {
    _cityService = cityService;
    _streetService = streetService;
    _houseService = houseService;
  }

  private readonly ICityService _cityService;

  private readonly IStreetService _streetService;

  private readonly IHouseService _houseService;

  [HttpGet("")]
  public async Task<IActionResult> GetCities()
  {
    try
    {
      return Ok(await _cityService.GetAll());
    }
    catch (Exception e)
    {
      return BadRequest(new { Error = e.Message });
    }
  }

  [HttpGet("{cityId}/streets")]
  public async Task<IActionResult> GetStreets(int cityId)
  {
    try
    {
      await _cityService.Get(cityId);
      return Ok(await _streetService.GetByCityId(cityId));
    }
    catch (NotFoundException e)
    {
      return NotFound(new { Error = e.Message });
    }
    catch (Exception e)
    {
      return BadRequest(new { Error = e.Message });
    }
 }

  [HttpGet("{cityId}/houses")]
  public async Task<IActionResult> GetHouses(int cityId)
  {
    try
    {
      await _cityService.Get(cityId);
      return Ok(await _houseService.GetByCityId(cityId));
    }
    catch (NotFoundException e)
    {
      return NotFound(new { Error = e.Message });
    }
    catch (Exception e)
    {
      return BadRequest(new { Error = e.Message });
    }
  }
}
