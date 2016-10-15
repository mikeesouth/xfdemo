using Xamarin.Forms;

namespace xfdemo.Controls.Custom
{
    public class ImageButton : Button
    {
        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), 
                                                                                       typeof(string),
                                                                                       typeof(ImageButton),
                                                                                       "");

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public ImageButton()
        {
            BackgroundColor = Color.Transparent;
        }
    }
}
