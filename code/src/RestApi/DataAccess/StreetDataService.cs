using System.Data.SqlClient;
using Dapper;
using RestApi.DataAccess.Models;
using RestApi.Exceptions;

namespace RestApi.DataAccess;

public class StreetDataService : IStreetDataService
{
  public StreetDataService(IConfiguration configuration)
  {
    _connectionString = configuration.GetConnectionString("Default");
  }

  private readonly string _connectionString;

  public async Task<IEnumerable<Street>> GetAll()
  {
    using var connection = new SqlConnection(_connectionString);
    return await connection.QueryAsync<Street>("select * from streets");
  }

  public async Task<Street> Get(int id)
  {
    using var connection = new SqlConnection(_connectionString);
    var result = await connection.QueryAsync<Street>("select * from streets where id = @id", new { id });
    if (!result.Any()) throw new NotFoundException($"street by id:{id} not found.");
    return result.First();
  }
}
