
using Xamarin.Forms;

namespace xfdemo.Controls.Native
{
    public class NativeImageButton : AbsoluteLayout
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(INativeImageButton), "");
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(INativeImageButton), null);
        public static readonly BindableProperty TapCommandProperty =
            BindableProperty.Create("TapCommand", typeof(Command), typeof(INativeImageButton), null, BindingMode.TwoWay, propertyChanged: OnTapCommandChange);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        private static void OnTapCommandChange(BindableObject bindable, object oldvalue, object newvalue)
        {
            NativeImageButton nativeImageButton = bindable as NativeImageButton;
            if (nativeImageButton != null)
            {
                nativeImageButton.tapGesture.Command = (Command)newvalue;
            }
        }

        public static INativeImageButton Implementation { get { return DependencyService.Get<INativeImageButton>(); } }
        public static bool HasImplementation { get { return Implementation != null; } }

        public TapGestureRecognizer tapGesture = new TapGestureRecognizer();

        public NativeImageButton()
        {
            if (!HasImplementation)
            {
                IsVisible = false;
                return;
            }

            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;

            View nativeImageButton = Implementation.BuildNativeImageButton(Text, Icon, () => { tapGesture.Command.Execute(null); });
            nativeImageButton.GestureRecognizers.Add(tapGesture);

            Children.Add(nativeImageButton);
        }
    }
}
