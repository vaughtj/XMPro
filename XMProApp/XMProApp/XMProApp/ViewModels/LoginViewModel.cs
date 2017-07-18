using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XMProApp.Models;
using XMProApp.Service;

namespace XMProApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        IPageDialogService _pageDialogService { get; set; }
        public DelegateCommand LoginCommand { get;  }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _pageDialogService = pageDialogService;
            IsBusy = false;
            Title = "Login";

            LoginCommand = new DelegateCommand(OnLoginCommandExecuted, LoginCommandCanExecute)
               .ObservesProperty(() => UserName)
               .ObservesProperty(() => Password);

            

        }
        public void Clear()
        {
            MessagingCenter.Send(this, "Clear");
        }

        private async void OnLoginCommandExecuted()
        {
            IsBusy = true;
            if (CrossConnectivity.Current.IsConnected)
            {
                //await Task.Delay(500);
                if (UserName == Password)
                {
                    await _navigationService.NavigateAsync("/Navigation/Parcel");
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync("Invalid Password", "Password and User Name must match.", "OK");
                }
            }
            else
            {
                IsBusy = false;
                await _pageDialogService.DisplayAlertAsync("No Network Connection", "You are currently not connected to a network. Please look at your network connections.", "OK");
            }
            IsBusy = false;
        }

        private bool LoginCommandCanExecute() =>
            !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password) && IsNotBusy;
    }
}
