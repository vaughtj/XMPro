using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMProApp.Models;
using XMProApp.Repository;

namespace XMProApp.ViewModels
{
    public class ParcelDetailViewModel : BaseViewModel
    {
        public DelegateCommand SaveCommand { get; }

        private bool _shouldSave;

        protected IParcelRepository _parcelRepository { get; }
        IPageDialogService _pageDialogService { get; }
        private Parcels _parcel;
        
        public bool shouldSave
        {
            get { return _shouldSave; }
            set  { SetProperty(ref _shouldSave, value); } 
        }

        public Parcels MyParcel
        {
            get {
                shouldSave = true;
                return _parcel;
            }
            set {
                SetProperty(ref _parcel, value);
            }
        }

        public ParcelDetailViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IParcelRepository parcelRepository) : base(navigationService, pageDialogService)
        {
            _parcelRepository = parcelRepository;
            _pageDialogService = pageDialogService;
            shouldSave = false;
            Title = "Parcel";

            SaveCommand = new DelegateCommand(SaveCommandExecuted, SaveCommandCanExecute)
                .ObservesProperty(() => shouldSave);
        }
        private async void SaveCommandExecuted()
        {
            IsBusy = true;

            //var result = await _parcelRepository.PutOdataItemAsync(MyParcel);
            var result = true;

            if (result)
            {
                await _pageDialogService.DisplayAlertAsync("Success", "Your Parcel record has been updated.", "OK");
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Failure", "Your parcel rcord could not be updated. Please try again.", "OK");
            }

            IsBusy = false;
        }

        private bool SaveCommandCanExecute() =>
            shouldSave;


        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            
            if (parameters.ContainsKey("Id"))
            {
                IsBusy = true;
                await Task.Run(async () => {
                    int Id = Convert.ToInt32(parameters["Id"]);

                    var result = await _parcelRepository.GetOdataItemAsync(Id);
                    MyParcel = (Parcels)result;
                    shouldSave = false;
                });
                IsBusy = false;


            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Not Found", "The Parcel you are looking for was not found.", "OK");
            }

        }
    }
}
