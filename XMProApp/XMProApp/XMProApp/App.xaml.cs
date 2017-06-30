using Prism.Ninject;
using XMProApp.Views;
using Xamarin.Forms;
using XMProApp.Repository;
using XMProApp.Service;

namespace XMProApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("Login");
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

        }
    }
}
