# RestApi1

The api following RESTful principle ...or trying follow. Represents information service by cities, streets, houses and apartments. Uses:
- .NET 6 platform
- MS SQL database
- Dapper as ORM
- xUnit for testing
    - FluentAssertions for easy asserting

## Contents

- [How to launch](#launch)
- [Endpoints](#endpoints)
- [App state](#state)

## Launch

1. Download project (or fork)
2. Setting project in appsetting.json
    - In "ConnectionStrings" change "Data source=\<your source\>;..." if you don't use "localhost" by default
    - In "Settings" change "FillTestData" field value "true" on "false" if you don't need test data
2. Build project
3. Run

[:arrow_up: Contents](#contents)

## Endpoints

- */cities* - gets all cities from database
    - */cities/{cityId}/streets* - gets streets in city by *cityId*
    - */cities/{cityId}/houses* - gets houses in city by *cityId*
- */streets* - gets all streets from database
    - */streets/{streetId}/houses* - gets houses on street by *streetId*
- */houses* - gets all houses from database
- */apartments* - gets all apartments from database

[:arrow_up: Contents](#contents)

## State

- [x] Data access layer
- [x] Business layer
- [x] Controllers layer
- [x] Tests
    - [x] Unit tests
    - [ ] Integration tests
- [x] Readme.md

[:arrow_up: Contents](#contents)
