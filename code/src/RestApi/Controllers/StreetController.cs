using Microsoft.AspNetCore.Mvc;
using RestApi.Exceptions;
using RestApi.Services;

namespace RestApi.Controllers;

[Route("streets")]
[ApiController]
public class StreetController : ControllerBase
{
  public StreetController(IStreetService streetService,
    IHouseService houseService)
  {
    _streetService = streetService;
    _houseService = houseService;
  }

  private readonly IStreetService _streetService;

  private readonly IHouseService _houseService;

  [HttpGet("")]
  public async Task<IActionResult> Get()
  {
    try
    {
      return Ok(await _streetService.GetAll());
    }
    catch (Exception e)
    {
      return BadRequest(new { Error = e.Message });
    }
  }

  [HttpGet("{streetId}/houses")]
  public async Task<IActionResult> GetHouses(int streetId)
  {
    try
    {
      await _streetService.Get(streetId);
      return Ok(await _houseService.GetByStreetId(streetId));
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
