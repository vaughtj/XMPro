using Prism.Ninject;
using XMProApp.Views;
using Xamarin.Forms;
using XMProApp.Repository;
using XMProApp.Service;
using XMProApp.Helpers;

using Plugin.Settings;
using XMProApp.ViewModels;

namespace XMProApp
{
    public partial class App : PrismApplication
    {
        public App(string dbPath, IPlatformInitializer initializer = null) : base(initializer)
        {
            AppViewModel._dbPath = dbPath;
            IDbFactory _dbFactory = new DbFactory();
            _dbFactory.Initialize(AppViewModel._dbPath);
            AppViewModel.LoadSettings();
        }


        protected override void OnInitialized()
        {
            InitializeComponent();

            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
            {
                NavigationService.NavigateAsync("Login");
            }
            else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
            {
                NavigationService.NavigateAsync("Login");
            }
            else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Desktop)
            {
                NavigationService.NavigateAsync("Login");
            }
            else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Unsupported)
            {
                NavigationService.NavigateAsync("Login");
            }
            else
            {
                NavigationService.NavigateAsync("Login");
            }
            
            //NavigationService.NavigateAsync("Navigation/Parcel");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>( "Navigation" );
            Container.RegisterTypeForNavigation<Login>( "Login" );
            Container.RegisterTypeForNavigation<Welcome>( "Welcome" );
            Container.RegisterTypeForNavigation<Parcel>("Parcel");
            Container.RegisterTypeForNavigation<ParcelDetail>("ParcelDetail");

            //Register Interfaces
            Container.Bind<IParcelRepository>().To<ParcelRepository>();
            Container.Bind<IDataService>().To<DataService>();
            Container.Bind<IDbFactory>().To<DbFactory>();

            Container.RegisterTypeForNavigation<Renderer>();
        }
    }
}
