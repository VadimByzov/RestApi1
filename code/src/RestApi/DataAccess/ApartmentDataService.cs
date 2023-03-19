using System.Data.SqlClient;
using Dapper;
using RestApi.DataAccess.Models;
using RestApi.Exceptions;

namespace RestApi.DataAccess;

public class ApartmentDataService : IApartmentDataService
{
  public ApartmentDataService(IConfiguration configuration)
  {
    _connectionString = configuration.GetConnectionString("Default");
  }

  private readonly string _connectionString;

  public async Task<IEnumerable<Apartment>> GetAll()
  {
    using var connection = new SqlConnection(_connectionString);
    return await connection.QueryAsync<Apartment>("select * from apartments");
  }

  public async Task<Apartment> Get(int id)
  {
    using var connection = new SqlConnection(_connectionString);
    var result = await connection.QueryAsync<Apartment>("select * from apartments where id = @id", new { id });
    if (!result.Any()) throw new NotFoundException($"apartment by id:{id} not found.");
    return result.First();
  }
}
