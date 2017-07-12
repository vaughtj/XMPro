using Android.Graphics;
using XMProApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(ButtonFontEffect), "CustomFontEffect")]
namespace XMProApp.Droid
{
    class ButtonFontEffect : PlatformEffect
    {
        Typeface oldFont;

        protected override void OnAttached()
        {
            if (Element is Button == false)
                return;

            var button = (Android.Widget.Button)Control;

            oldFont = button.Typeface;
            
            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "Pacifico.ttf"); 
            button.Typeface = font;
        }

        protected override void OnDetached()
        {
            if (oldFont != null)
            {
                var button = (Android.Widget.Button)Control;

                button.Typeface = oldFont;
            }
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
        }
    }
}