using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers;

[Route("streets")]
[ApiController]
public class StreetController : ControllerBase
{
  public StreetController()
  {

  }

  [HttpGet("{streetId}/houses")]
  public async Task<IActionResult> GetHouses(string streetId)
  {
    // перечень домов с указанием полного адреса и количества квартир с запросом по конкретной улице / городу
    return Ok("streets/houses");
  }
}
