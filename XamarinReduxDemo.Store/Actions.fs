namespace XamarinReduxDemo.Store

type StoreAction =
    | CityAdded of City
    | CityRemoved of City
    | UserUpdated of User
