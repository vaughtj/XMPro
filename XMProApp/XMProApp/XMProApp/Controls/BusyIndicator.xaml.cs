using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XMProApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusyIndicator : Grid
    {
        //public static readonly BindableProperty boolProperty = BindableProperty.Create(nameof(ImBusy), typeof(bool), typeof(BusyIndicator), false, BindingMode.TwoWay, null, null);

        //public bool ImBusy
        //{
        //    get
        //    {
        //        return (bool)GetValue(boolProperty);
        //    }
        //    set
        //    {
        //        SetValue(boolProperty, value);
        //    }
        //}

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(BusyIndicator));

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public BusyIndicator ()
		{
			InitializeComponent ();
		}
	}
}