using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XMProApp.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private string _name;
        private string _welcomeMessage;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { SetProperty(ref _welcomeMessage, value); }
        }
        public WelcomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Welcome";
        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Name"))
                Name = (string)parameters["Name"];

            WelcomeMessage = "Welcome " + Name + "!";
        }
    }
}
