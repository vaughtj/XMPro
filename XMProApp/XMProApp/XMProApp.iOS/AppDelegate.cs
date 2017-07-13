using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Ninject;
using Prism.Ninject;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfPullToRefresh.XForms.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;

namespace XMProApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            SetupAppearance();

            global::Xamarin.Forms.Forms.Init();
            new SfBusyIndicatorRenderer();
            SfListViewRenderer.Init();
            SfPullToRefreshRenderer.Init();

            string dbPath = FileAccessHelper.GetLocalFilePath("XMPro.db3");

            LoadApplication(new App(dbPath, new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }

        private static void SetupAppearance()
        {
            //UISwitch.Appearance.OnTintColor = UIColor.Orange;
            //UISlider.Appearance.MinimumTrackTintColor = UIColor.Magenta;
            //UISlider.Appearance.MaximumTrackTintColor = UIColor.Cyan;
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(51, 134, 238);
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            { TextColor = UIColor.White, Font = UIFont.ItalicSystemFontOfSize(20) });
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IKernel kernel)
        {

        }
    }

}
