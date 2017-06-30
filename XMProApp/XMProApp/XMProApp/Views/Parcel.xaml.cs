using Prism.Navigation;
using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XMProApp.ViewModels;

namespace XMProApp.Views
{
    public partial class Parcel : ContentPage
    {
        INavigationService _navigationService;
        public Parcel(INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
            

            //Pull to Refresh
            pullToRefresh.Refreshed += PullToRefresh_Refreshed;
            pullToRefresh.Pulling += PullToRefresh_Pulling;
            pullToRefresh.Refreshing += PullToRefresh_Refreshing;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private async void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            pullToRefresh.IsRefreshing = true;
            await Task.Delay(250);
            await _navigationService.NavigateAsync("/Navigation/Parcel");
            pullToRefresh.IsRefreshing = false;
        }

        private void PullToRefresh_Pulling(object sender, PullingEventArgs args)
        {
            args.Cancel = false;
            var prog = args.Progress;
        }

        private void PullToRefresh_Refreshed(object sender, EventArgs args)
        {
            pullToRefresh.IsRefreshing = false;
        }
    }
}
