using FluentAssertions;
using RestApi.Exceptions;
using RestApi.Services;
using RestApi.xUnitTests.Mocks;

namespace RestApi.xUnitTests;

public class CityServiceTests
{
  [Fact]
  public async void GetAll_HaveOneItems_ShouldReturnOneItem()
  {
    // arrange
    var data = new List<DataAccess.Models.City>
    {
      new() { Id = 1, Name = "1" },
    };

    var expected = new List<Models.City>
    {
      new() { Id = 1, Name = "1" },
    };

    var mockDataService = new MockCityDataService(data);
    var service = new CityService(mockDataService);

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
    var data = new List<DataAccess.Models.City>
    {
      new() { Id = 1, Name = "1" },
      new() { Id = 2, Name = "2" },
      new() { Id = 3, Name = "3" },
    };

    var expected = new List<Models.City>
    {
      new() { Id = 1, Name = "1" },
      new() { Id = 2, Name = "2" },
      new() { Id = 3, Name = "3" },
    };

    var mockDataService = new MockCityDataService(data);
    var service = new CityService(mockDataService);

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
    var data = new List<DataAccess.Models.City>
    {
      new() { Id = 1, Name = "1" },
    };

    var expected = new Models.City { Id = 1, Name = "1" };

    var mockDataService = new MockCityDataService(data);
    var service = new CityService(mockDataService);

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
    var data = new List<DataAccess.Models.City>
    {
      new() { Id = 1, Name = "1" },
      new() { Id = 2, Name = "2" },
      new() { Id = 3, Name = "3" },
      new() { Id = 4, Name = "4" },
    };

    var expected = new Models.City { Id = 3, Name = "3" };

    var mockDataService = new MockCityDataService(data);
    var service = new CityService(mockDataService);

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
    var data = new List<DataAccess.Models.City>
    {
      new() { Id = 1, Name = "1" },
      new() { Id = 2, Name = "2" },
      new() { Id = 3, Name = "3" },
      new() { Id = 4, Name = "4" },
    };

    var mockDataService = new MockCityDataService(data);
    var service = new CityService(mockDataService);

    // act
    var actual = async () => await service.Get(id);

    // assert
    await actual
      .Should().ThrowAsync<NotFoundException>();
  }
}
