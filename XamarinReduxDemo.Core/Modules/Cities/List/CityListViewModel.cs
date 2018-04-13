using System;
using MvvmNano;
using XamarinReduxDemo.Core.Shared;
using XamarinReduxDemo.Store;

namespace XamarinReduxDemo.Core.Modules.Cities
{
    public class CityListViewModel : ViewModelBase
    {
        public SmartCollection<City> Cities { get; }

        private MvvmNanoCommand<City> _removeCityCommand;
        public MvvmNanoCommand<City> RemoveCityCommand 
            => _removeCityCommand ?? 
               (_removeCityCommand = new MvvmNanoCommand<City>(OnRemoveCity));

        public CityListViewModel(IStore store) : base(store)
        {
            Cities = new SmartCollection<City>();
            
            ConnectToStore(state => state.Cities, cities =>
            {
                Cities.Reset(cities);
            });
        }
        
        private void OnRemoveCity(City city)
        {
            Store.Dispatch(StoreAction.NewCityRemoved(city));
        }

        private MvvmNanoCommand<City> _addCommand;
        public MvvmNanoCommand<City> AddCommand
            => _addCommand ??
        ( _addCommand = new MvvmNanoCommand<City>(OnAddCity));

        private void OnAddCity(City city)
        {
            var rnd = new Random();

            CityId i = CityId.NewCityId( rnd.Next());
            var amsterdam = new City(id: i, name: "Amsterdam " + i.Item);
                
            //let amsterdam = { City.Id = CityId(020); Name = "Amsterdam"};
            Store.Dispatch(StoreAction.NewCityAdded(amsterdam));
        }
    }
}
