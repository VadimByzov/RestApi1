using System.Data.SqlClient;
using Dapper;
using RestApi.DataAccess.Models;
using RestApi.Exceptions;

namespace RestApi.DataAccess;

public class CityDataService : ICityDataService
{
  public CityDataService(IConfiguration configuration)
  {
    _connectionString = configuration.GetConnectionString("Default");
  }

  private readonly string _connectionString;

  public async Task<IEnumerable<City>> GetAll()
  {
    using var connection = new SqlConnection(_connectionString);
    return await connection.QueryAsync<City>("select * from cities");
  }

  public async Task<City> Get(int id)
  {
    using var connection = new SqlConnection(_connectionString);
    var result = await connection.QueryAsync<City>("select * from cities where id = @id", new { id });
    if (!result.Any()) throw new NotFoundException($"city by id:{id} not found.");
    return result.First();
  }
}
