using Android.Support.Design.Widget;
using xfdemo.Controls.Native;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(xfdemo.Droid.Controls.Native.FloatingButton))]
namespace xfdemo.Droid.Controls.Native
{
    public class FloatingButton : IFloatingButton
    {
        public View BuildFloatingButton(System.Action clickAction)
        {
            FloatingActionButton fButton = new FloatingActionButton(Forms.Context)
            {
                UseCompatPadding = false
            };
            fButton.SetImageResource(Resource.Drawable.ic_facebook_white);
            fButton.Click += (sender, e) => { clickAction(); };

            return fButton.ToView();
        }
    }
}