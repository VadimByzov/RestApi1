﻿using RestApi.DataAccess;
using RestApi.Models;

namespace RestApi.Services;

public class StreetService : IStreetService
{
  public StreetService(IStreetDataService streetDataService)
  {
    _streetDataService = streetDataService;
  }

  private readonly IStreetDataService _streetDataService;
  
  public async Task<Street> Get(int id)
  {
    var dataStreet = await _streetDataService.Get(id);
    return new Street
    {
      Id = dataStreet.Id,
      Name = dataStreet.Name,
      CityId = dataStreet.City_Id,
    };
  }

  public async Task<IEnumerable<Street>> GetAll()
  {
    var dataStreets = await _streetDataService.GetAll();
    return dataStreets.Select(s => new Street
    {
      Id = s.Id,
      Name = s.Name,
      CityId = s.City_Id,
    });
  }

  public async Task<IEnumerable<Street>> GetByCityId(int cityId)
  {
    var dataStreets = await _streetDataService.GetByCityId(cityId);
    return dataStreets.Select(s => new Street
    {
      Id = s.Id,
      Name = s.Name,
      CityId = s.City_Id
    });
  }
}
