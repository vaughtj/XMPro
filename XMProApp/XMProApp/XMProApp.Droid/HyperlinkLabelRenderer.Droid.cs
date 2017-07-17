using Android.Text.Util;
using Android.Widget;
using XMProApp.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XMProApp.Droid;

[assembly: ExportRenderer(typeof(HyperlinkLabel), typeof(HyperlinkLabelRenderer))]
namespace XMProApp.Droid
{
    class HyperlinkLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            Linkify.AddLinks(Control, MatchOptions.All);
        }
    }
}
