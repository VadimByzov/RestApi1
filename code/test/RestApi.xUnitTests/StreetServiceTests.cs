using FluentAssertions;
using RestApi.Exceptions;
using RestApi.Services;
using RestApi.xUnitTests.Mocks;

namespace RestApi.xUnitTests;

public class StreetServiceTests
{
  [Fact]
  public async void GetAll_HaveOneItems_ShouldReturnOneItem()
  {
    // arrange
    var data = new List<DataAccess.Models.Street>
    {
      new() { Id = 1, Name = "1", City_Id = 1 },
    };

    var expected = new List<Models.Street>
    {
      new() { Id = 1, Name = "1", CityId = 1 },
    };

    var mockDataService = new MockStreetDataService(data);
    var service = new StreetService(mockDataService);

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
    var data = new List<DataAccess.Models.Street>
    {
      new() { Id = 1, Name = "1", City_Id = 1 },
      new() { Id = 1, Name = "1", City_Id = 1 },
      new() { Id = 1, Name = "1", City_Id = 1 },
    };

    var expected = new List<Models.Street>
    {
      new() { Id = 1, Name = "1", CityId = 1 },
      new() { Id = 1, Name = "1", CityId = 1 },
      new() { Id = 1, Name = "1", CityId = 1 },
    };

    var mockDataService = new MockStreetDataService(data);
    var service = new StreetService(mockDataService);

    // act
    var actual = await service.GetAll();

    // assert
    actual
      .Should().NotBeNullOrEmpty()
      .And.HaveCount(expected.Count)
      .And.BeEquivalentTo(expected);
  }

  [Fact]
  public async void Get_HaveMoreThanOneItems_ShouldReturnOneItem()
  {
    // arrange
    var data = new List<DataAccess.Models.Street>
    {
      new() { Id = 1, Name = "1", City_Id = 1 },
      new() { Id = 2, Name = "2", City_Id = 2 },
      new() { Id = 3, Name = "3", City_Id = 3 },
      new() { Id = 4, Name = "4", City_Id = 4 },
    };

    var expected = new Models.Street { Id = 3, Name = "3", CityId = 3 };

    var mockDataService = new MockStreetDataService(data);
    var service = new StreetService(mockDataService);

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
    var data = new List<DataAccess.Models.Street>
    {
      new() { Id = 1, Name = "1", City_Id = 1 },
      new() { Id = 2, Name = "2", City_Id = 2 },
      new() { Id = 3, Name = "3", City_Id = 3 },
      new() { Id = 4, Name = "4", City_Id = 4 },
    };

    var mockDataService = new MockStreetDataService(data);
    var service = new StreetService(mockDataService);

    // act
    var actual = async () => await service.Get(id);

    // assert
    await actual
      .Should().ThrowAsync<NotFoundException>();
  }

  [Theory]
  [InlineData(1)]
  [InlineData(2)]
  [InlineData(3)]
  [InlineData(4)]
  public async void GetByCityId_ValidId_ShouldReturnOneItem(int cityId)
  {
    // arrange
    var data = new List<DataAccess.Models.Street>
    {
      new() { Id = 1, Name = "1", City_Id = 1 },
      new() { Id = 2, Name = "2", City_Id = 2 },
      new() { Id = 3, Name = "3", City_Id = 3 },
      new() { Id = 4, Name = "4", City_Id = 4 },
    };

    var expected = new List<Models.Street>
    {
      new () { Id = cityId, Name = cityId.ToString(), CityId = cityId }
    };

    var mockDataService = new MockStreetDataService(data);
    var service = new StreetService(mockDataService);

    // act
    var actual = await service.GetByCityId(cityId);

    // assert
    actual
      .Should().NotBeNull()
      .And.BeEquivalentTo(expected);
  }

  [Theory]
  [InlineData(0)]
  [InlineData(5)]
  [InlineData(int.MaxValue)]
  [InlineData(int.MinValue)]
  public async void GetByCityId_InvalidId_ShouldReturnEmptyList(int cityId)
  {
    // arrange
    var data = new List<DataAccess.Models.Street>
    {
      new() { Id = 1, Name = "1", City_Id = 1 },
      new() { Id = 2, Name = "2", City_Id = 2 },
      new() { Id = 3, Name = "3", City_Id = 3 },
      new() { Id = 4, Name = "4", City_Id = 4 },
    };

    var mockDataService = new MockStreetDataService(data);
    var service = new StreetService(mockDataService);

    // act
    var actual = await service.GetByCityId(cityId);

    // assert
    actual
      .Should().NotBeNull()
      .And.BeEmpty();
  }
}
