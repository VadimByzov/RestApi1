using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers;

[Route("cities")]
[ApiController]
public class CityController : ControllerBase
{
  public class City
  {
    public int Id { get; set; }

    public string Name { get; set; }
  }

  public CityController()
  {

  }

  [HttpGet("")]
  public async Task<IActionResult> GetCities()
  {
    // перечень городов с указанием количества домов
    var path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
    var sqlpath = Path.Combine(path, @"sqlscripts/mssql");
    var files = Directory.GetFiles(sqlpath);
    return Ok(files);
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
