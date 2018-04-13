module Tests
open XamarinReduxDemo.Store
open System
open Xunit

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``Can create user test`` () = 
    let user = {User.Id = UserId(1); Name = "Martijn"};

    Assert.Equal("Martijn", user.Name)

[<Fact>]
let ``Can create city test`` () = 
    let amsterdam = { City.Id = CityId(020); Name = "Amsterdam"};

    Assert.Equal("Amsterdam", amsterdam.Name)
    Assert.Equal(CityId(20), amsterdam.Id)

[<Fact>]
let ``Check state test`` () =
    let state = InitialState.Create()
    Assert.IsType<AppState>(state)
