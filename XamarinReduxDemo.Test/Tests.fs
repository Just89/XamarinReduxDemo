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

[<Fact>]
let ``Check remove city from state`` () =
    let state = InitialState.Create()

    let store = new Store(
                    state,
                    RootReducer.Create()
                ) :> IStore
               

    let cityToBeRemoved = state.Cities.[0]

    store.Dispatch(StoreAction.CityRemoved(cityToBeRemoved));

    Assert.DoesNotContain(cityToBeRemoved, store.CurrentState.Cities)

[<Fact>]
let ``Check add city to state`` () =
     // Arrange
     let state = InitialState.Create()

     let store = new Store(
                     state,
                     RootReducer.Create()
                 ) :> IStore

     let amsterdam = { City.Id = CityId(020); Name = "Amsterdam"};

     // Act
     store.Dispatch(StoreAction.CityAdded(amsterdam))

     // Assert 
     Assert.Contains(amsterdam, store.CurrentState.Cities)