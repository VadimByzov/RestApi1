using Microsoft.AspNetCore.Mvc;
using RestApi.Services;

namespace RestApi.Controllers;

[Route("apartments")]
[ApiController]
public class ApartmentController : ControllerBase
{
  public ApartmentController(IApartmentService apartmentService)
  {
    _apartmentService = apartmentService;
  }

  private readonly IApartmentService _apartmentService;

  [HttpGet("")]
  public async Task<IActionResult> GetAll()
  {
    try
    {
      return Ok(await _apartmentService.GetAll());
    }
    catch (Exception e)
    {
      return BadRequest(new { Error = e.Message });
    }
  }
}
