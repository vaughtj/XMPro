using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XMProApp.Models;
using XMProApp.Repository;
using XMProApp.Service;

namespace XMProApp.ViewModels
{
    public class ParcelViewModel : BaseViewModel
    {
        public ICommand AddCommand => new Command<Parcels>(async (item) => await GoToDetail(item));

        protected IParcelRepository _parcelRepository { get; }
        IPageDialogService _pageDialogueService { get; }

        INavigationService _navigateService;

        private ObservableCollection<Parcels> _parcels;
        public ObservableCollection<Parcels> MyParcels
        {
            get { return _parcels; }
            set { SetProperty(ref _parcels, value); }
        }

        public ParcelViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IParcelRepository parcelRepository) : base(navigationService)
        {
            _pageDialogueService = pageDialogService;
            _parcelRepository = parcelRepository;
            _navigateService = navigationService;

            Title = "Parcels";
        }

        private async Task<bool> GoToDetail(Parcels item)
        {
            await _navigationService.NavigateAsync("ParcelDetail?Id=" + item.ParcelID);

            return true;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            IsBusy = true;
            var result = await _parcelRepository.GetItemsAsync();
            MyParcels = new ObservableCollection<Parcels>(result);
            IsBusy = false;
        }
    }

}
