using XMProApp.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(ButtonFontEffect), "CustomFontEffect")]
namespace XMProApp.iOS
{
    class ButtonFontEffect : PlatformEffect
    {
        UIFont oldFont;

        protected override void OnAttached()
        {
            if (Element is Button == false)
                return;

            var button = Control as UIButton;

            oldFont = button.Font;

            button.Font = UIFont.FromName("Pacifico", button.Font.PointSize);
        }

        protected override void OnDetached()
        {
            if(oldFont != null)
            {
                var button = Control as UIButton;
                button.Font = oldFont;
            }
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
        }
    }
}