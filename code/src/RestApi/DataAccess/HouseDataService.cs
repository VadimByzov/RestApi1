using System.Data.SqlClient;
using Dapper;
using RestApi.DataAccess.Models;
using RestApi.Exceptions;

namespace RestApi.DataAccess;

public class HouseDataService : IHouseDataService
{
  public HouseDataService(IConfiguration configuration)
  {
    _connectionString = configuration.GetConnectionString("Default");
  }

  private readonly string _connectionString;

  public async Task<IEnumerable<House>> GetAll()
  {
    using var connection = new SqlConnection(_connectionString);
    return await connection.QueryAsync<House>("select * from houses");
  }

  public async Task<House> Get(int id)
  {
    using var connection = new SqlConnection(_connectionString);
    var result = await connection.QueryAsync<House>("select * from houses where id = @id", new { id });
    if (!result.Any()) throw new NotFoundException($"house by id:{id} not found.");
    return result.First();
  }
}
