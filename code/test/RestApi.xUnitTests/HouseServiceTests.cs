using FluentAssertions;
using RestApi.Exceptions;
using RestApi.Services;
using RestApi.xUnitTests.Mocks;

namespace RestApi.xUnitTests;

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
public class HouseServiceTests
{
  [Fact]
  public async void GetAll_HaveOneItems_ShouldReturnOneItem()
  {
    // arrange
    var data = new List<DataAccess.Models.House>
    {
      new() { Id = 1, Number = "1", Street_Id = 1 },
    };

    var expected = new List<Models.House>
    {
      new() { Id = 1, Number = "1", StreetId = 1 },
    };

    var mockDataService = new MockHouseDataService(data, null);
    var service = new HouseService(mockDataService);

    // act
    var actual = await service.GetAll();

    // assert
    actual
      .Should().NotBeNullOrEmpty()
      .And.HaveCount(expected.Count)
      .And.BeEquivalentTo(expected);
  }

  [Fact]
  public async void GetAll_HaveMoreThanOneItems_ShouldReturnMoreThanOneItems()
  {
    // arrange
    var data = new List<DataAccess.Models.House>
    {
      new() { Id = 1, Number = "1", Street_Id = 1 },
      new() { Id = 2, Number = "2", Street_Id = 2 },
      new() { Id = 3, Number = "3", Street_Id = 3 },
    };

    var expected = new List<Models.House>
    {
      new() { Id = 1, Number = "1", StreetId = 1 },
      new() { Id = 2, Number = "2", StreetId = 2 },
      new() { Id = 3, Number = "3", StreetId = 3 },
    };

    var mockDataService = new MockHouseDataService(data, null);
    var service = new HouseService(mockDataService);

    // act
    var actual = await service.GetAll();

    // assert
    actual
      .Should().NotBeNullOrEmpty()
      .And.HaveCount(expected.Count)
      .And.BeEquivalentTo(expected);
  }

  [Fact]
  public async void Get_HaveOneItems_ShouldReturnOneItem()
  {
    // arrange
    var data = new List<DataAccess.Models.House>
    {
      new() { Id = 1, Number = "1", Street_Id = 1 },
    };

    var expected = new Models.House { Id = 1, Number = "1", StreetId = 1 };

    var mockDataService = new MockHouseDataService(data, null);
    var service = new HouseService(mockDataService);

    // act
    var actual = await service.Get(expected.Id);

    // assert
    actual
      .Should().NotBeNull()
      .And.BeEquivalentTo(expected);
  }

  [Fact]
  public async void Get_HaveMoreThanOneItems_ShouldReturnOneItem()
  {
    // arrange
    var data = new List<DataAccess.Models.House>
    {
      new() { Id = 1, Number = "1", Street_Id = 1 },
      new() { Id = 2, Number = "2", Street_Id = 2 },
      new() { Id = 3, Number = "3", Street_Id = 3 },
      new() { Id = 4, Number = "4", Street_Id = 4 },
    };

    var expected = new Models.House { Id = 3, Number = "3", StreetId = 3 };

    var mockDataService = new MockHouseDataService(data, null);
    var service = new HouseService(mockDataService);

    // act
    var actual = await service.Get(expected.Id);

    // assert
    actual
      .Should().NotBeNull()
      .And.BeEquivalentTo(expected);
  }

  [Theory]
  [InlineData(-1)]
  [InlineData(int.MinValue)]
  [InlineData(int.MaxValue)]
  public async void Get_HaveMoreThanOneItems_InvalidId_ShouldThrowsNotFoundException(int id)
  {
    // arrange
    var data = new List<DataAccess.Models.House>
    {
      new() { Id = 1, Number = "1", Street_Id = 1 },
      new() { Id = 2, Number = "2", Street_Id = 2 },
      new() { Id = 3, Number = "3", Street_Id = 3 },
      new() { Id = 4, Number = "4", Street_Id = 4 },
    };

    var mockDataService = new MockHouseDataService(data, null);
    var service = new HouseService(mockDataService);

    // act
    var actual = async () => await service.Get(id);

    // assert
    await actual
      .Should().ThrowAsync<NotFoundException>();
  }

  [Fact]
  public async void GetByStreetId_HaveOneItems_ValidId_ShouldReturnOneItemList()
  {
    // arrange
    var data = new List<DataAccess.Models.House>
    {
      new() { Id = 1, Number = "1", Street_Id = 1 },
    };

    var expected = new List<Models.House>
    {
      new() { Id = 1, Number = "1", StreetId = 1 },
    };

    var mockDataService = new MockHouseDataService(data, null);
    var service = new HouseService(mockDataService);

    // act
    var actual = await service.GetByStreetId(1);

    // assert
    actual
      .Should().NotBeNullOrEmpty()
      .And.HaveCount(expected.Count)
      .And.BeEquivalentTo(expected);
  }

  [Fact]
  public async void GetByStreetId_HaveMoreThanOneItems_ValidId_ShouldReturnOneItemList()
  {
    // arrange
    var data = new List<DataAccess.Models.House>
    {
      new() { Id = 1, Number = "1", Street_Id = 1 },
      new() { Id = 2, Number = "2", Street_Id = 2 },
      new() { Id = 3, Number = "3", Street_Id = 3 },
    };

    var expected = new List<Models.House>
    {
      new() { Id = 2, Number = "2", StreetId = 2 },
    };

    var mockDataService = new MockHouseDataService(data, null);
    var service = new HouseService(mockDataService);

    // act
    var actual = await service.GetByStreetId(2);

    // assert
    actual
      .Should().NotBeNullOrEmpty()
      .And.HaveCount(expected.Count)
      .And.BeEquivalentTo(expected);
  }

  [Fact]
  public async void GetByStreetId_HaveMoreThanOneItems_InvalidId_ShouldReturnEmptyList()
  {
    // arrange
    var data = new List<DataAccess.Models.House>
    {
      new() { Id = 1, Number = "1", Street_Id = 1 },
      new() { Id = 2, Number = "2", Street_Id = 2 },
      new() { Id = 3, Number = "3", Street_Id = 3 },
    };

    var expected = new List<Models.House>
    {
      new() { Id = 4, Number = "4", StreetId = 4 },
    };

    var mockDataService = new MockHouseDataService(data, null);
    var service = new HouseService(mockDataService);

    // act
    var actual = await service.GetByStreetId(4);

    // assert
    actual
      .Should().NotBeNull()
      .And.BeEmpty();
  }

  [Fact]
  public async void GetByCityId_HaveMoreThanOneItems_ValidId_ShouldReturnOneItemList()
  {
    // arrange
    var dataHouses = new List<DataAccess.Models.House>
    {
      new() { Id = 1, Number = "1", Street_Id = 1 },
      new() { Id = 2, Number = "2", Street_Id = 2 },
      new() { Id = 3, Number = "3", Street_Id = 3 },
    };

    var dataStreets = new List<DataAccess.Models.Street>
    {
      new() { Id = 1, Name = "1", City_Id = 1 },
    };

    var expected = new List<Models.House>
    {
      new() { Id = 1, Number = "1", StreetId = 1 },
    };

    var mockDataService = new MockHouseDataService(dataHouses, dataStreets);
    var service = new HouseService(mockDataService);

    // act
    var actual = await service.GetByCityId(1);

    // assert
    actual
      .Should().NotBeNullOrEmpty()
      .And.HaveCount(expected.Count)
      .And.BeEquivalentTo(expected);
  }

  [Fact]
  public async void GetByCityId_HaveMoreThanOneItems_InvalidId_ShouldReturnEmptyList()
  {
    // arrange
    var dataHouses = new List<DataAccess.Models.House>
    {
      new() { Id = 1, Number = "1", Street_Id = 1 },
      new() { Id = 2, Number = "2", Street_Id = 2 },
      new() { Id = 3, Number = "3", Street_Id = 3 },
    };

    var dataStreets = new List<DataAccess.Models.Street>
    {
      new() { Id = 1, Name = "1", City_Id = 1 },
    };

    var mockDataService = new MockHouseDataService(dataHouses, dataStreets);
    var service = new HouseService(mockDataService);

    // act
    var actual = await service.GetByCityId(2);

    // assert
    actual
      .Should().NotBeNull()
      .And.BeEmpty();
  }
}
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
