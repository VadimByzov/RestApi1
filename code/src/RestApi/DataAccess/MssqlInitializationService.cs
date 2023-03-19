using System.Data.SqlClient;
using Dapper;

namespace RestApi.DataAccess;

public class MssqlInitializationService : IDatabaseInitializationService
{
  public MssqlInitializationService(IConfiguration configuration)
  {
    _configuration = configuration;
    _sqlPath = Path.Combine(
      Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())),
      @"sqlscripts\mssql");
  }

  private readonly IConfiguration _configuration;

  private readonly string _sqlPath;

  public void Initialize()
  {
    CreateDb();
    CreateTables();

    if (bool.Parse(_configuration["Settings:FillTestData"]))
    {
      FillTestData();
    }
  }

  private void CreateDb()
  {
    using var connection = new SqlConnection(_configuration.GetConnectionString("Master"));
    connection.Execute(File.ReadAllText(Path.Combine(_sqlPath, "1 create db.sql")));
  }

  private void CreateTables()
  {
    using var connection = new SqlConnection(_configuration.GetConnectionString("Default"));
    connection.Execute(File.ReadAllText(Path.Combine(_sqlPath, "2 create cities.sql")));
    connection.Execute(File.ReadAllText(Path.Combine(_sqlPath, "3 create streets.sql")));
    connection.Execute(File.ReadAllText(Path.Combine(_sqlPath, "4 create houses.sql")));
    connection.Execute(File.ReadAllText(Path.Combine(_sqlPath, "5 create apartments.sql")));
  }

  private void FillTestData()
  {
    using var connection = new SqlConnection(_configuration.GetConnectionString("Default"));
    connection.Execute(File.ReadAllText(Path.Combine(_sqlPath, "6 fill test data.sql")));
  }
}
 