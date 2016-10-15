using Xamarin.Forms;

namespace xfdemo.Controls.Native
{
    public class FloatingButton : AbsoluteLayout
    {
        public static readonly BindableProperty TapCommandProperty = 
            BindableProperty.Create("TapCommand", typeof(Command), typeof(FloatingButton), null, BindingMode.TwoWay, propertyChanged: OnTapCommandChange);

        private static void OnTapCommandChange(BindableObject bindable, object oldvalue, object newvalue)
        {
            FloatingButton floatingButton = bindable as FloatingButton;
            if (floatingButton != null)
                floatingButton.tapGesture.Command = (Command)newvalue;
        }

        public static IFloatingButton Implementation { get { return DependencyService.Get<IFloatingButton>(); } }
        public static bool HasImplementation { get { return Implementation != null; } }

        public TapGestureRecognizer tapGesture = new TapGestureRecognizer();

        public FloatingButton()
        {
            if (!HasImplementation)
            {
                IsVisible = false;
                return;
            }

            HorizontalOptions = LayoutOptions.End;

            View floatingButton = Implementation.BuildFloatingButton(() => { tapGesture.Command.Execute(null); });
            floatingButton.GestureRecognizers.Add(tapGesture);

            Children.Add(floatingButton);
        }
    }
}
