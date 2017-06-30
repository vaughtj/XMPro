using Newtonsoft.Json;
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
using XMProApp.Models;
using XMProApp.Service;

namespace XMProApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        IPageDialogService _pageDialogService { get;  }
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

        public LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            IsBusy = false;
            Title = "Login";

            LoginCommand = new DelegateCommand(OnLoginCommandExecuted, LoginCommandCanExecute)
               .ObservesProperty(() => UserName)
               .ObservesProperty(() => Password);
        }



        private async void OnLoginCommandExecuted()
        {
            IsBusy = true;

            //await Task.Delay(500);
            if (UserName == Password)
            {
                await _navigationService.NavigateAsync("/Navigation/Parcel");                
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Invalid Password", "Password and User Name must match.", "OK");
            }
            IsBusy = false;
        }

        private bool LoginCommandCanExecute() =>
            !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password) && IsNotBusy;
    }
}
