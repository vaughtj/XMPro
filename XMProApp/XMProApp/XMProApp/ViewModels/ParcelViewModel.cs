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
using Syncfusion.ListView.XForms;
using Syncfusion.DataSource;

namespace XMProApp.ViewModels
{
    public class ParcelViewModel : BaseViewModel
    {
        #region Command Fields

        Command<Syncfusion.ListView.XForms.ItemTappedEventArgs> tapCommand;
        Command<Parcels> swipeImageCommand;
        Command<SfListView> loadedCommand;
        Command<SwipingEventArgs> swipeCommand;

        #endregion

        #region Command Properties

        public Command<Syncfusion.ListView.XForms.ItemTappedEventArgs> TapCommand
        {
            get { return tapCommand; }
            protected set { tapCommand = value; }
        }

        public Command<SfListView> LoadedCommand
        {
            get { return loadedCommand; }
            protected set { loadedCommand = value; }
        }

        public Command<Parcels> SwipeImageCommand
        {
            get { return swipeImageCommand; }
            protected set { swipeImageCommand = value; }
        }

        public Command<SwipingEventArgs> SwipeCommand
        {
            get { return swipeCommand; }
            protected set { swipeCommand = value; }
        }

        #endregion

        protected IParcelRepository _parcelRepository { get; }
        IPageDialogService _pageDialogueService { get; }

        INavigationService _navigateService;

        private ObservableCollection<Parcels> _parcels;
        public ObservableCollection<Parcels> MyParcels
        {
            get { return _parcels; }
            set { SetProperty(ref _parcels, value); }
        }

        public ParcelViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IParcelRepository parcelRepository) : base(navigationService, pageDialogService)
        {
            _pageDialogueService = pageDialogService;
            _parcelRepository = parcelRepository;
            _navigateService = navigationService;

            Title = "Parcels";



            tapCommand = new Command<Syncfusion.ListView.XForms.ItemTappedEventArgs>(OnTapped);
            loadedCommand = new Command<SfListView>(OnListViewLoaded);
            swipeImageCommand = new Command<Parcels>(OnSwipeImageTapped);
            swipeCommand = new Command<SwipingEventArgs>(OnSwipeCommand);

        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            IsBusy = true;

            await Task.Run(async () =>
            {
                var result = await _parcelRepository.GetItemsAsync();
                MyParcels = new ObservableCollection<Parcels>(result);
            });

            IsBusy = false;
        }

        #region Command Events

        public void OnListViewLoaded(SfListView listView)
        {
            if (listView.DataSource.GroupDescriptors.Count > 0)
                return;

            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "CustomerName",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as Parcels);
                    return item.CustomerName[0].ToString();
                },
            });
        }

        public void OnTapped(Syncfusion.ListView.XForms.ItemTappedEventArgs eventArgs)
        {
            var id = (eventArgs.ItemData as Parcels).ParcelID;
            _navigationService.NavigateAsync("ParcelDetail?Id=" + id);
        }

        public void OnSwipeCommand(SwipingEventArgs eventArgs)
        {
            if (eventArgs.SwipeOffSet >= 150)
                eventArgs.Handled = true;
        }

        public async void OnSwipeImageTapped(Parcels parcels)
        {
            await _pageDialogueService.DisplayAlertAsync("Sorry!!!", "Delete functionallity currently not enabled.", "OK");
        }

        #endregion
    }

}
