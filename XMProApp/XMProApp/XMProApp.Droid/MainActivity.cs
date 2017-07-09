using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Ninject;
using Prism.Ninject;

namespace XMProApp.Droid
{
    [Activity(Label = "XMProApp", Theme = "@style/splashscreen", Icon = "@drawable/icon", 
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTop)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {


            base.Window.RequestFeature(WindowFeatures.ActionBar);
            // Name of the MainActivity theme you had there before.
            // Or you can use global::Android.Resource.Style.ThemeHoloLight
            base.SetTheme(Resource.Style.MyTheme_Base);

            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            string dbPath = FileAccessHelper.GetLocalFilePath("XMPro.db3");
            LoadApplication(new App(dbPath, new AndroidInitializer()));
        }

    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IKernel kernel)
        {

        }
    }
}

