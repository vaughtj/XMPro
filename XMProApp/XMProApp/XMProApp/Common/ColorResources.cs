using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XMProApp.Common
{
    public static class ColorResources
    {
        public static readonly Color ListTextColor = Device.OnPlatform(Color.Blue, Color.Green, Color.Red);
    }
}
