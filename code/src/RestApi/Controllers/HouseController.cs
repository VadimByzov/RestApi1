using Microsoft.AspNetCore.Mvc;
using RestApi.Services;

namespace RestApi.Controllers;

[Route("houses")]
[ApiController]
public class HouseController : ControllerBase
{
  public HouseController(IHouseService houseService)
  {
    _houseService = houseService;
  }

  private readonly IHouseService _houseService;

  [HttpGet("")]
  public async Task<IActionResult> GetAll()
  {
    try
    {
      return Ok(await _houseService.GetAll());
    }
    catch (Exception e)
    {
      return BadRequest(new { Error = e.Message });
    }
  }
}
