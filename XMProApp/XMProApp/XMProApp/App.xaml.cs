using Prism.Ninject;
using XMProApp.Views;
using Xamarin.Forms;
using XMProApp.Repository;
using XMProApp.Service;

namespace XMProApp
{
    public partial class App : PrismApplication
    {
        public static string _dbPath;
        public App(string dbPath, IPlatformInitializer initializer = null) : base(initializer)
        {
            _dbPath = dbPath;
            IDbFactory _dbFactory = new DbFactory();
            _dbFactory.Initialize(_dbPath);
        }

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
            Container.Bind<IDbFactory>().To<DbFactory>();

        }
    }
}
