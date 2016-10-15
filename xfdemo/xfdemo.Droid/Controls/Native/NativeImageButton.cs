using Android.Support.Design.Widget;
using Android.Support.V7.View;
using Android.Widget;
using xfdemo.Controls.Native;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(xfdemo.Droid.Controls.Native.NativeImageButton))]
namespace xfdemo.Droid.Controls.Native
{
    public class NativeImageButton : INativeImageButton
    {
        public View BuildNativeImageButton(string text, string icon, System.Action clickAction)
        {
            if (string.IsNullOrWhiteSpace(text))
                text = "(text binding not set)";
            if (string.IsNullOrWhiteSpace(icon))
                icon = "ic_facebook_white.png";

            Android.Widget.Button imgButton = new Android.Widget.Button(Forms.Context)
            {
                Text = text
            };

            if (!string.IsNullOrWhiteSpace(icon))
            {
                int imgRes = 0;
                if (icon == "ic_facebook_white.png")
                    imgRes = Resource.Drawable.ic_facebook_white;
                if (imgRes != 0)
                    imgButton.SetCompoundDrawablesWithIntrinsicBounds(imgRes, 0, 0, 0);
            }
            imgButton.Click += (sender, e) => { clickAction(); };
            imgButton.SetBackgroundResource(Resource.Drawable.bg_button_border);

            var paddingInPixels = ConvertDpToPixels(10);
            imgButton.SetPadding(paddingInPixels, 0, paddingInPixels, 0);
            
            imgButton.TextAlignment = Android.Views.TextAlignment.Center;

            return imgButton.ToView();
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Forms.Context.Resources.DisplayMetrics.Density);
            return dp;
        }

        private int ConvertDpToPixels(float dpValue)
        {
            var px = (int)((dpValue) * Forms.Context.Resources.DisplayMetrics.Density);
            return px;
        }
    }
}